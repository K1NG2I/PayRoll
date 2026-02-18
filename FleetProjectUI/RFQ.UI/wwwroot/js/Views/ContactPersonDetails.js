var contactPersonList = [];

$(document).ready(function () {

    // Cancel button
    $('#btnCancelContactPerson').on('click', function (e) {
        e.preventDefault();
        CancelContactPerson();
    });

    // Add button
    $('#btnAddContactPerson').on('click', function (e) {
        e.preventDefault();
        ClearContactPersonForm();
        $('#contactPersonListSection').hide();
        $('#contactPersonFormSection').show();
    });

    SaveContactPerson(); // 👈 REQUIRED (like UpdateEmployee)
});


// =========================
// LOAD LIST (Called from Employee.js)
// =========================
function LoadContactPersons(employeeId) {

    if (!employeeId || employeeId <= 0) return;

    $.ajax({
        type: "GET",
        url: "/ContactPersonDetails/GetByEmployee",
        data: { employeeId: employeeId },
        success: function (result) {

            contactPersonList = result || [];
            RenderContactPersonTable();
        },
        error: function () {
            toastr.error("Failed to load contact persons");
        }
    });
}


// =========================
// RENDER TABLE
// =========================
function RenderContactPersonTable() {

    var tbody = $('#contactPersonTableBody');
    tbody.empty();

    if (!contactPersonList || contactPersonList.length === 0) {
        tbody.append(`
            <tr>
                <td colspan="6">No contact persons found</td>
            </tr>
        `);
        return;
    }

    contactPersonList.forEach(item => {

        tbody.append(`
            <tr>
                <td>${item.relation}</td>
                <td>${item.contactPersonName}</td>
                <td>${item.aadhaarNumber || ''}</td>
                <td>${item.panNumber || ''}</td>
                <td>${item.isActive ? 'Active' : 'Inactive'}</td>
                <td>
                    <a href="#" onclick="EditContactPerson(${item.contactPersonDetailId})">
                        <i class="ri-edit-line"></i>
                    </a>
                    <a href="#" class="ms-2 text-danger"
                       onclick="DeleteContactPerson(${item.contactPersonDetailId})">
                        <i class="ri-delete-bin-line"></i>
                    </a>
                </td>
            </tr>
        `);
    });
}


// =========================
// EDIT
// =========================
function EditContactPerson(contactPersonDetailId) {

    console.log("EditContactPerson called with:", contactPersonDetailId);

    var item = contactPersonList.find(x => x.contactPersonDetailId == contactPersonDetailId);
    if (!item) {
        toastr.error("Contact person not found");
        return;
    }

    // CRITICAL: Set hidden ID first
    $('#hdnContactPersonDetailId').val(item.contactPersonDetailId);

    // Bind values
    $('#txtRelation').val(item.relation);
    $('#txtContactPersonName').val(item.contactPersonName);
    $('#txtContactAadhaar').val(item.aadhaarNumber);
    $('#txtContactPan').val(item.panNumber);
    $('#ddlContactStatus').val(item.isActive.toString());

    // Toggle UI
    $('#contactPersonListSection').hide();
    $('#contactPersonFormSection').show();
}


// =========================
// SAVE / UPDATE (Employee-style binding)
// =========================
function SaveContactPerson() {

    $('#btnSaveContactPerson').off('click').on('click', function (e) {

        e.preventDefault();

        var employeeId = $('#hdnEmployeeId').val();
        if (!employeeId) {
            toastr.warning("Employee not selected");
            return;
        }

        var request = {
            ContactPersonDetailId: $('#hdnContactPersonDetailId').val() || 0,
            EmployeeId: employeeId,
            Relation: $('#txtRelation').val(),
            ContactPersonName: $('#txtContactPersonName').val(),
            AadhaarNumber: $('#txtContactAadhaar').val(),
            PanNumber: $('#txtContactPan').val(),
            IsActive: $('#ddlContactStatus').val() === "true"
        };

        console.log("Sending ContactPerson payload:", request);

        var isUpdate = request.ContactPersonDetailId > 0;
        var url = isUpdate
            ? "/ContactPersonDetails/Update"
            : "/ContactPersonDetails/Add";

        $.ajax({
            type: isUpdate ? "PUT" : "POST",
            url: url,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(request),
            success: function (result) {

                if (result.result === "success") {

                    toastr.success(result.message || "Operation successful");

                    LoadContactPersons(employeeId);

                    $('#contactPersonFormSection').hide();
                    $('#contactPersonListSection').show();
                }
                else {
                    toastr.error(result.message || "Failed to save contact person");
                }
            },
            error: function () {
                toastr.error("Error saving contact person");
            }
        });

    });
}


// =========================
// DELETE (Aligned to employee success style)
// =========================
function DeleteContactPerson(contactPersonDetailId) {

    Swal.fire({
        title: 'Are you sure?',
        text: "This will deactivate the contact person",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {

        if (!result.isConfirmed) return;

        $.ajax({
            type: "DELETE",
            url: `/ContactPersonDetails/Delete?contactPersonDetailId=${contactPersonDetailId}`,
            success: function (result) {

                if (result.result === "success") {

                    toastr.success(result.message || "Deleted successfully");

                    LoadContactPersons($('#hdnEmployeeId').val());
                }
                else {
                    toastr.error(result.message || "Delete failed");
                }
            },
            error: function () {
                toastr.error("Error deleting contact person");
            }
        });
    });
}


// =========================
// CANCEL
// =========================
function CancelContactPerson() {

    ClearContactPersonForm();

    $('#contactPersonFormSection').hide();
    $('#contactPersonListSection').show();
}


// =========================
// CLEAR FORM
// =========================
function ClearContactPersonForm() {

    $('#hdnContactPersonDetailId').val('');
    $('#txtRelation').val('');
    $('#txtContactPersonName').val('');
    $('#txtContactAadhaar').val('');
    $('#txtContactPan').val('');
    $('#ddlContactStatus').val('true');
}
