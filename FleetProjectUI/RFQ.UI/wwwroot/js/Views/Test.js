$(document).ready(function () {
    FetchDataForTable('tabletest', '/Test/ViewTestList', null, null, 'EditTest', null, 'testId');
    UpdateTest(); // 👈 REQUIRED
});

function ViewTest(testId) {
    EditTest(testId);
    $('#testFormSection')
        .find('input, select, textarea, button')
        .prop('disabled', true);

    $('#btnUpdateTest').hide();
}

function EditTest(testId) {

    var data = viewModelDto.filter(x => x.testId == testId);
    if (data.length === 0) {
        toastr.error("Test data not found");
        return;
    }

    var test = data[0];

    // UI toggle (same pattern)
    $('#testListSection').hide();
    $('#testFormSection').show();

    $('#btnSaveTest').hide();
    $('#btnUpdateTest').show();

    // Bind values
    console.log("Binding test data:", test); // 👈 DEBUG LINE
    console.log("Test ID:", test.testId); // 👈 DEBUG LINE
    $('#hdnTestId').val(test.testId)
    $('#txtTestName').val(test.personName);
    $('#txtCompany').val(test.company);
    $('#txtLocation').val(test.location);
    $('#txtMobileNo').val(test.mobileNo);
    $('#txtEmailId').val(test.emailId);
    $('#ddlStatus').val(test.isActive.toString());

}
function UpdateTest() {
    $('#btnUpdateTest').off('click').on('click', function (e) {
        e.preventDefault();

        var testDto = {
            TestId: parseInt($('#hdnTestId').val()),
            PersonName: $('#txtPersonName').val(),
            Company: $('#txtCompany').val(),
            Location: $('#txtLocation').val(),
            MobileNo: $('#txtMobileNo').val(),
            EmailId: $('#txtEmailId').val(),
            IsActive: $('#ddlStatus').val() === "true" // ✅ IMPORTANT
        };

        console.log("Sending payload:", console.log(JSON.stringify(testDto))); // 👈 DEBUG LINE

        $.ajax({
            type: "PUT",
            url: "/Test/EditTest",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(testDto),
            success: function (result) {
                if (result.result === "success") {
                    toastr.success("Test updated successfully");

                    FetchDataForTable(
                        'tabletest',
                        '/Test/ViewTestList',
                        null,
                        null,
                        'EditTest',
                        null,
                        'testId'
                    );

                    $('#testFormSection').hide();
                    $('#testListSection').show();
                } else {
                    toastr.error(result.message || "Failed to update test");
                }
            },
            error: function () {
                toastr.error("Error updating test");
            }
        });
    });
}
