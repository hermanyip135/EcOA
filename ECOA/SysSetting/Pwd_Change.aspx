<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pwd_Change.aspx.cs" Inherits="SysSetting_Pwd_Change" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>密码修改</title>
		<script language=javascript>
		function DataCheck()
		{
		    if(!window.confirm("是否确定提交？"))
			{
				return false;
            }
            if (document.all("txtOld").value.length == 0) {
                alert("请输入旧密码！");
                return false;
            }	
			if(document.all("txtNew1").value.length==0)
			{
				alert("请输入新密码！");
				return false;
			}
			if(document.all("txtNew1").value.length<6)
			{
				alert("新密码必须6位以上！");
				return false;
			}		
			if(document.all("txtNew1").value!=document.all("txtNew2").value)
			{
				alert("新密码确认错误！");
				return false;
			}	
							
			return true;
		}
		</script>
		<base target="_self">
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server" defaultbutton="lbtnSave">
			<BR>
			<CENTER>
				<TABLE>
					<TR>
						<TD>
						<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD class="td">
										<TABLE cellSpacing="1" cellPadding="0" bgColor="#b0b0b0">
											<TR>
												<TD>
													<TABLE cellSpacing="0" cellPadding="10" bgColor="#f0f0e8">
														<TR>
															<TD >
                                                                <table border="0" cellpadding="2" cellspacing="0">
                                                                    <tr>
                                                                        <td class="ttTable" nowrap="nowrap" align="left">
                                                                            工号</td>
                                                                        <td class="td" nowrap="nowrap" align="left">
                                                                            <asp:TextBox ID="txtAccount" runat="server" CssClass="edline " MaxLength="20" Width="184px"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="ttTable" nowrap="nowrap">
                                                                            旧密码</td>
                                                                        <td align="left" class="td" nowrap="nowrap">
                                                                            <asp:TextBox ID="txtOld" runat="server" CssClass="edline " MaxLength="20" Width="184px" TextMode="Password"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="ttTable" nowrap="nowrap">
                                                                            新密码</td>
                                                                        <td align="left" class="td" nowrap="nowrap">
                                                                            <asp:TextBox ID="txtNew1" runat="server" CssClass="edline " MaxLength="20" Width="184px" TextMode="Password"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="ttTable" nowrap="nowrap">
                                                                            新密码确认</td>
                                                                        <td align="left" class="td" nowrap="nowrap">
                                                                            <asp:TextBox ID="txtNew2" runat="server" CssClass="edline " MaxLength="20" Width="184px" TextMode="Password"></asp:TextBox></td>
                                                                    </tr>
                                                                    
                                                                </table>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="left">
							<TABLE cellSpacing="3" cellPadding="0" border="0">
								<TR vAlign="middle">
									<TD class="td" noWrap align="center" id=tdSave runat=server>
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD><INPUT type="image" src="../Images/button_left.gif"></TD>
												<TD vAlign="middle" noWrap background="../Images/button_bg.gif">&nbsp;
												<asp:LinkButton id="lbtnSave" runat="server" OnClick="lbtnSave_Click"  CssClass="linkbutton">提交</asp:LinkButton>&nbsp;</TD>
												<TD><IMG src="../Images/button_right.gif" border="0"></TD>
											</TR>
										</TABLE>
										
									</TD>
									<TD class="td" noWrap align="center" id=tdReset runat=server>
									
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD><INPUT type="image" src="../Images/button_left.gif"></TD>
												<TD vAlign="middle" noWrap background="../Images/button_bg.gif">&nbsp;
													<asp:LinkButton id="lbtnReset" runat="server"  CssClass="linkbutton">重置</asp:LinkButton>&nbsp;</TD>
												<TD><IMG src="../Images/button_right.gif" border="0"></TD>
											</TR>
										</TABLE>
									</TD>								
								</TR>
                                
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
			<asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
		</form>
	</body>
</HTML>


