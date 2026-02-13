var contactPersonList = [];

// =========================
// INIT (called when employee edit opens)
// =========================
function LoadContactPersons(employeeId) {
    if (!employeeId || employeeId <= 0) return;

    $.ajax({
        url: '/ContactPersonDetails/GetByEmployee',
        type: 'GET',
        data: { employeeId: employeeId },
        success: function (response) {
            contactPersonList = response || [];
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

    if (contactPersonList.length === 0) {
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
// ADD BUTTON
// =========================
$('#btnAddContactPerson').on('click', function (e) {
    e.preventDefault();
    ClearContactPersonForm();
    $('#contactPersonListSection').hide();
    $('#contactPersonFormSection').show();
});

// =========================
// EDIT
// =========================
function EditContactPerson(id) {
    var item = contactPersonList.find(x => x.contactPersonDetailId === id);
    if (!item) return;

    $('#hdnContactPersonDetailId').val(item.contactPersonDetailId);
    $('#txtRelation').val(item.relation);
    $('#txtContactPersonName').val(item.contactPersonName);
    $('#txtContactAadhaar').val(item.aadhaarNumber);
    $('#txtContactPan').val(item.panNumber);
    $('#ddlContactStatus').val(item.isActive.toString());

    $('#contactPersonListSection').hide();
    $('#contactPersonFormSection').show();
}

// =========================
// SAVE (ADD / UPDATE)
// =========================
$('#btnSaveContactPerson').on('click', function (e) {
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
        IsActive: $('#ddlContactStatus').val() === 'true'
    };

    var isUpdate = request.ContactPersonDetailId > 0;
    var url = isUpdate
        ? '/ContactPersonDetails/Update'
        : '/ContactPersonDetails/Add';

    $.ajax({
        url: url,
        type: isUpdate ? 'PUT' : 'POST',
        contentType: 'application/json',
        data: JSON.stringify(request),
        success: function (res) {
            if (res.isSuccess) {
                toastr.success(res.message);
                LoadContactPersons(employeeId);
                CancelContactPerson();
            } else {
                toastr.error(res.message || "Operation failed");
            }
        },
        error: function () {
            toastr.error("Failed to save contact person");
        }
    });
});

// =========================
// DELETE
// =========================
function DeleteContactPerson(id) {
    var updatedBy = 1; // TODO: replace with logged-in user id

    Swal.fire({
        title: 'Are you sure?',
        text: "This will deactivate the contact person",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (!result.isConfirmed) return;

        $.ajax({
            url: `/ContactPersonDetails/Delete/${id}/${updatedBy}`,
            type: 'DELETE',
            success: function (res) {
                if (res.isSuccess) {
                    toastr.success(res.message);
                    LoadContactPersons($('#hdnEmployeeId').val());
                } else {
                    toastr.error(res.message);
                }
            },
            error: function () {
                toastr.error("Failed to delete contact person");
            }
        });
    });
}

// =========================
// CANCEL
// =========================
$('#btnCancelContactPerson').on('click', function (e) {
    e.preventDefault();
    CancelContactPerson();
});

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
