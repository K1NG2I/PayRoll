
$(document).ready(function () {

    // Load employee list
    FetchEmployee();

    // Cancel button
    $('#btnCancelEmployee').on('click', function () {
        $('#employeeFormSection').hide();
        $('#employeeListSection').show();
    });

    UpdateEmployee(); // 👈 REQUIRED
});

// =========================
// FETCH LIST
// =========================
function FetchEmployee() {
    FetchDataForTable(
        'tableemployee',
        '/Employee/ViewEmployeeList',
        null,
        null,
        'EditEmployee',
        null,
        'employeeId'
    );
}

// =========================
// VIEW (READ ONLY – optional)
// =========================
function ViewEmployee(employeeId) {
    EditEmployee(employeeId);
    $('#employeeFormSection')
        .find('input, select, textarea, button')
        .prop('disabled', true);

    $('#btnUpdateEmployee').hide();
}

// =========================
// EDIT
// =========================
function EditEmployee(employeeId) {

    console.log("EditEmployee called with:", employeeId);

    var employee = viewModelDto.find(x => x.employeeId == employeeId);
    if (!employee) {
        toastr.error("Employee not found");
        return;
    }

    // Reset contact person UI
    $('#contactPersonFormSection').hide();
    $('#contactPersonListSection').show();

    // Set hidden ID FIRST (CRITICAL)
    $('#hdnEmployeeId').val(employee.employeeId);

    // Load contact persons AFTER ID is set
    LoadContactPersons(employee.employeeId);

    // Bind values
    $('#txtFullName').val(employee.fullName);
    $('#txtContactNumber').val(employee.contactNumber);
    $('#txtAadhaarNumber').val(employee.aadhaarNumber);
    $('#txtPanNumber').val(employee.panNumber);
    $('#txtSalary').val(employee.salary);
    $('#txtHireDate').val(employee.hireDate);
    $('#ddlStatus').val(employee.isActive.toString());

    // Toggle UI
    $('#employeeListSection').hide();
    $('#employeeFormSection').show();
    $('#btnUpdateEmployee').show();
}


// =========================
// UPDATE
// =========================
function UpdateEmployee() {
    $('#btnUpdateEmployee').off('click').on('click', function (e) {
        e.preventDefault();

        var employeeDto = {
            EmployeeId: $('#hdnEmployeeId').val(),
            FullName: $('#txtFullName').val(),
            ContactNumber: $('#txtContactNumber').val(),
            AadhaarNumber: $('#txtAadhaarNumber').val(),
            PanNumber: $('#txtPanNumber').val(),
            Salary: $('#txtSalary').val(),
            HireDate: $('#txtHireDate').val(),
            IsActive: $('#ddlStatus').val() === "true"
        };

        console.log("Sending Employee payload:", employeeDto);

        $.ajax({
            type: "PUT",
            url: "/Employee/EditEmployee",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(employeeDto),
            success: function (result) {
                if (result.result === "success") {
                    toastr.success("Employee updated successfully");

                    FetchEmployee();

                    $('#employeeFormSection').hide();
                    $('#employeeListSection').show();
                } else {
                    toastr.error(result.message || "Failed to update employee");
                }
            },
            error: function () {
                toastr.error("Error updating employee");
            }
        });
    });
}
