<%@ Page Title="" Language="C#" MasterPageFile="~/Views/User/Auction/Auction.Master" AutoEventWireup="true" CodeBehind="addgrides.aspx.cs" Inherits="Second_hand.Views.User.Auction.addgrides" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div classs="row">
            <div class="col-4"></div>
            <div class="col-4"><h1 class="text-success text-center">商品管理</h1></div>
            <div class="col-4"></div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <form>
                    <div class="mb-3">
                    <label for="UserTb" class="form-label">商品名称</label>
                    <input type="text" class="form-control" id="gride_name" runat="server" required="required">
   
                    </div>
                    <div class="mb-3">
                    <label for="PasswordTb" class="form-label">商品价格</label>
                    <input type="text" class="form-control" id="price" runat="server" required="required">
                    <label id="price_judge" runat="server"></label>
                    </div>

                    <div class="mb-3">
                    <label for="gride_type" class="form-label">商品类型</label>
                    <input type="text" class="form-control" id="Text2" runat="server" required="required">
                    </div>

  
                    <div class="d-grid"> 
                        <label id="add" runat="server"></label>
                        <asp:Button ID="addbtn" runat="server" Text="添加" class="btn btn-success btn-block" OnClick="addbtn_Click"/>
                    </div>
                    <br />

                  
            </form>
                
            </div>
            <div class="col-md-9">               
                 <asp:GridView ID="grideview2" runat="server" 
                     class="table" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" OnSelectedIndexChanged="grideview1_SelectedIndexChanged" 
                     >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="选择"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" Height="800px" />
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
