<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeManager.aspx.cs" Inherits="Comp600ContactManager.EmployeeManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
   <style>
        body {background-color: powderblue;}
        h1 , p  {color: black;}
        .texbMargin {margin: 0px 10px;}
        .formdiv {
            border: 3px solid white;
            border-radius: 10px;
            padding: 15px;
            margin: 37px;
        }
        .title{ text-align: center;}
</style>
</head>
<body>
    <div class="title">
        <h1>
        Contact Manager Application
            </h1>
    </div>
    <form id="form1" runat="server">
        <div class="formdiv">
        
        <p style="height: 50px">
            Employee Id
            <asp:TextBox class="texbMargin" ID="empId" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Street
            <asp:TextBox class="texbMargin" ID="street" runat="server"></asp:TextBox>
        </p>
        <p style="height: 50px">
            First Name
            <asp:TextBox class="texbMargin" ID="firstName" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            City
            <asp:TextBox class="texbMargin" ID="city" runat="server"></asp:TextBox>

        </p>

        <p style="height: 50px">
            Last Name
            <asp:TextBox class="texbMargin" ID="lastName" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Province
            <asp:TextBox class="texbMargin" ID="province" runat="server"></asp:TextBox>

        </p>

        <p style="height: 50px">
            Middle Init
            <asp:TextBox class="texbMargin" ID="middleInit" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Postal Code
            <asp:TextBox class="texbMargin" ID="postalCode" runat="server"></asp:TextBox>

        </p>

        <p style="height: 50px">
            Phone No
            <asp:TextBox class="texbMargin" ID="phoneNo" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Job Title
            <asp:TextBox class="texbMargin" ID="jobTitle" runat="server"></asp:TextBox>

        </p>


        <p style="height: 50px">
            
            <asp:Button ID="previousButton" runat="server" Text="<<" OnClick="previousButton_Click" Width="98px" />
            <asp:Button ID="nextButton" runat="server" Text=">>" OnClick="nextButton_Click" Width="87px" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Earnings $
            <asp:TextBox ID="weeklyEarnings" runat="server" Width="194px"></asp:TextBox>

            <asp:Button ID="getSalaryButton" runat="server" Text="Get Salary" OnClick="getSalaryButton_Click" style="margin-left: 66px" Width="271px" />

        </p>

        <p style="height: 50px">
            Employee No
            <asp:TextBox ID="empNoSearch" runat="server" Width="217px"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" style="margin-left: 62px" Width="206px" />
            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click1" style="margin-left: 70px" Width="180px" />

        </p>

         <p style="height: 50px">
            <asp:Button ID="timeSheetButton" runat="server" Text="TimeSheet" OnClick="timeSheetButton_Click" style= Width="180px" />

          </p>
            </div>
        
    </form>
</body>
</html>
