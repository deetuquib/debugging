<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.Models.RegisterCourse" %>

<system.webServer>
    <directoryBrowse enabled="true" />
</system.webServer>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Algonquin: Course Registration</title>

        <%-- Use Bootstrap to style the page --%>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
        <%-- Jquery required by Bootstrap  --%>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
        <%-- Bootstrap's Javascript library --%>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

        <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />

    </head>

    <body class="bg-secondary">
        <div class="container bg-light mt-5">

            <!-- Form -->
        <form id="form1" runat="server">
            <h1>Algonquin College Course Registration</h1>

            <hr />

            <!-- Student Info -->
            <div class="row"><h4>
                <!-- Student Name -->
                <div class="col">
                    <asp:Label runat="server" ID="studentNameLabel">Student Name: </asp:Label>
                </div>
                <!-- Student Name Text Box -->
                <div class="col">
                    <asp:TextBox runat="server" ID="studentName" CssClass="input"></asp:TextBox>
                </div>
                <!-- Student Status Radio Button -->
                <div class="col">
                    <asp:Label runat="server" ID="studentStatus" ></asp:Label>
                <asp:RadioButtonList runat="server" ID="studentStatusList" RepeatDirection="Horizontal">
                    <asp:ListItem ID="fullTime">Full Time</asp:ListItem>
                    <asp:ListItem ID="partTime">Part Time</asp:ListItem>
                    <asp:ListItem ID="coOp">Co-op</asp:ListItem>
                </asp:RadioButtonList>
                </div>
            </h4></div>

            <!-- Error Message -->
            <div>
                <asp:Label runat="server" ID="errorMessage" Visible="false" CssClass="text-danger"></asp:Label>
            </div>
            <div class="mb-5">
                <!-- Panel1 -->
                <asp:Panel runat="server" ID="chooseCourses">
                    <!-- Checklist -->
                    <asp:CheckBoxList runat="server" ID="courseChecklist" />
                    <!-- Submit -->
                    <asp:Button runat="server" ID="submit" Text="Submit" OnClick="button_Click" />
                </asp:Panel>

                <!-- Panel2 -->
                <asp:Panel runat="server" ID="confirmationPanel">
                    <!-- Label "has enrolled in the followin courses" -->
                    <asp:Label runat="server" ID="label"></asp:Label>
                    <!-- Confirmation -->
                    <asp:Table runat="server" ID="confirmationTable" CssClass="table">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="distinct">Course Code</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="distinct">Course Title</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="distinct">Weekly Hours</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </asp:Panel>
            </div>
        </form>

        </div>

        
    </body>
</html>
