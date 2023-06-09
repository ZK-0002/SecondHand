<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin1.aspx.cs" Inherits="Second_hand.Views.Admin.Admin1" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div classs="row">
            <div class="col-4"></div>
            <div class="col-4"><h1 class="text-success text-center">拍卖会管理</h1></div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <form>
                    <div class="mb-3">
                    <label for="UserTb" class="form-label">拍卖会开始时间</label>
                    <input type="datetime-local" step="1" class="form-control" id="astarttime" runat="server" required="required">
   
                    </div>
                    <div class="mb-3">
                    <label for="PasswordTb" class="form-label">拍卖会结束时间</label>
                    <input type="datetime-local" step="1" class="form-control" id="aendtime" runat="server" required="required">
                    <label id="price_judge" runat="server"></label>
                    </div>

                    <div class="mb-3">
                    <label for="auction_place" class="form-label">拍卖会地点</label>
                     <input type="text" class="form-control" id="place" runat="server" required="required">
                    </div>

  
                    <div class="d-grid"> 
                        <label id="add" runat="server"></label>
                        <asp:Button ID="aaddbtn" runat="server" Text="添加" class="btn btn-success btn-block" OnClick="aaddbtn_Click"/>
                    </div>
                    <br />

                    <div class="d-grid">       
                        <asp:Button ID="adelebtn" runat="server" Text="删除" class="btn btn-success btn-block" OnClick="adelebtn_Click"/>
                    </div>
                    <br />

                    <div class="d-grid">       
                        <asp:Button ID="arebtn" runat="server" Text="修改" class="btn btn-success btn-block" OnClick="arebtn_Click"/>
                    </div>
                    <br />

                    
            </form>
                
            </div>
            <div class="col-md-9">               
                <asp:GridView ID="agrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="选择"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView> 

            </div>
        </div>
   </div>

</asp:Content>
