///增加集团审批
function AddGroups(EmployeeID, EmployeeName, Purview, MainID, idx) {
    if (confirm("确定要集团审核？")) {

        $.ajax({
            url: "/Ajax/Flow_Handler.ashx",
            type: "post",
            dataType: "text",
            data: 'action=SaveGroups&id=' + EmployeeID + '&name=' + EmployeeName + '&purview=' + Purview + '&mainid=' + MainID + '&idx=' + idx,
            success: function (info) {
                if (info == "success") {
                    alert('已增加集团审批');
                    location = location;
                }
                else if (info == "NoPower")
                    alert("未开通编辑权限");
                else if (info == "Conpleted") {
                    alert("该表已审批完毕，不能再修改了！");

                }
                else if ("Existed" == info) {
                    alert("已增加集团审批");
                }
                else
                    alert(info);
            }
        })

    }

}