<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="VivoExamWeb.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Content Wrapper. Contains page content -->
      <script type="text/javascript" src="../plugins/jquery/jquery.min.js"></script>
  <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark">
                            Dashboard</h1>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Dashboard</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->
        <!-- Main content -->
    <Section class="content">
      <div class="container-fluid">
       <!-- Main row -->
        <div class="row">
          <div class="col-md-4">
            <!-- Info Boxes Style 2 -->
               <!-- PRODUCT LIST -->
            <div class="card" style="overflow: scroll;height: 567px;">
              <div class="card-header">
                <h3 class="card-title" style="font-weight: 600">Active And UpComming Exam </h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-widget="collapse">
                    <i class="fas fa-minus"></i>
                  </button>
                  <button type="button" class="btn btn-tool" data-widget="remove">
                    <i class="fas fa-times"></i>
                  </button>
                </div>
              </div>
              <!-- /.card-header -->
              <div class="card-body p-0">
                <ul class="products-list product-list-in-card pl-2 pr-2" id="ExamItem" runat="server">
               
                </ul>
              </div>
              <!-- /.card-body -->
              <div class="card-footer text-center">
               
              </div>
              <!-- /.card-footer -->
            </div>
            <!-- /.card -->
            </div>
          <!-- Left col -->
          <div class="col-md-8">

          <iframe name="myIframe" id="myIframe" src="Icon/Exam application Usage instruction and Rules.png" width="100%" height="100%" runat="server"></iframe>
            <!-- MAP & BOX PANE -->
              <!-- TABLE: LATEST ORDERS -->
          <%--  <div class="card">
              <div class="card-header border-transparent">
                <h3 class="card-title" style="font-weight: 600">Top 10 Topper List</h3>

                <div class="card-tools">
                  <button type="button" class="btn btn-tool" data-widget="collapse">
                    <i class="fas fa-minus"></i>
                  </button>
                  <button type="button" class="btn btn-tool" data-widget="remove">
                    <i class="fas fa-times"></i>
                  </button>
                </div>
              </div>
            
              <div class="card-body p-0">
                <div class="table-responsive">
                            
     <asp:Panel ID="Panel1" runat="server" class="panelStyle">
            <asp:GridView ID="MaterialGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover"
               AllowPaging="True" PageSize="100" ShowHeaderWhenEmpty="true"  
                AllowSorting="True">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No" HeaderStyle-Wrap="true" >
                        <ItemTemplate>
                            <asp:Label ID="lblSNo" runat="server" Text="<%# (Container.DataItemIndex)+1 %>"> 
                            </asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Wrap="True" />
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="User Id" >
                        <ItemTemplate>
                            <asp:Label ID="lbl_user_id" runat="server" Text='<%# Bind("user_id") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                       
                   <asp:Label ID="lbl_Username" runat="server" Text='<%# Bind("Username") %>'></asp:Label>        
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Dept" >
                        <ItemTemplate>
                            <asp:Label ID="lbl_Dept" runat="server" Text='<%# Bind("Dept") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Exam No" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_exam_no" runat="server" Text='<%# Bind("exam_no") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Exam Name">
                        <ItemTemplate>
                            <asp:Label ID="lbl_exam_name" runat="server" Text='<%# Bind("exam_name") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Category" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                   <asp:TemplateField HeaderText="Start Date" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Startdate" runat="server" Text='<%# Bind("Startdate") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="DateTime">
                        <ItemTemplate>
                            <asp:Label ID="lbl_SubmitDate" runat="server" Text='<%# Bind("SubmitDate")%>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marks" >
                        <ItemTemplate>
                            <asp:Label ID="lbl_Marks" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                </Columns>
                <EmptyDataTemplate>
                    No Record Available</EmptyDataTemplate>
            </asp:GridView>
        </asp:Panel>
  
           
            <br /> <br />  
                </div>
               
              </div>
          
            </div>--%>
           

            </div>
             </div>
        <!-- /.row -->
      </div><!--/. container-fluid -->
    </section>
        <!-- /.content -->
    </div>
    <script type="text/javascript">
        
    </script>
</asp:Content>
