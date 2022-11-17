<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSheet.aspx.cs" Inherits="Comp600ContactManager.TimeSheet" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Payroll Data Form</title>
</head>
<body>
    <form>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <select name="payroll" id="payroll">
                              <option value="default">Choose One Option</option>
                              <option value="prev">Previous Week</option>
                              <option value="curr">Current Week</option>
                              <option value="next">Next Week</option>
                        </td>
                        <td style="float:left;">&nbsp;&nbsp;<input type="submit" value="submit"></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="submit" value="Back"></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <td>
            <table>
                <tr>
                    <td>EmpID</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Starting and ending week dates</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <!--<input type="text" value=""></td>-->
                   <input type="date" id="start" name="trip-start" value="2022-11-16" min="1900-01-01" max="2099-12-31">
                    </br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input type="date" id="start" name="trip-start" value="2022-11-16" min="1900-01-01" max="2099-12-31">
                </tr>
                <tr>
                    <td>Monday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Tuesday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Wednesday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Thursday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Friday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Saturday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Sunday</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>Total weekly hours</td><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="text" value=""></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center">
                        <table>
                            <tr>
                                <td align="center"><input type="submit" value="Submit"></td>
                                <td align="center"><input type="submit" value="Update"></td>
                            </tr>
                        </table>
                    </td>
                </tr>

            <table>
        </td>
        </tr>
    </form>
</body>
</html>
