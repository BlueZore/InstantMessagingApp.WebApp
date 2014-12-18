<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseUserView.aspx.cs" Inherits="InstantMessagingApp.BaseUserView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
        }

        body {
            background-color: #ebf2fa;
        }

        .userlayer {
            width: 300px;
            height: 220px;
        }

        .userLayer_header {
            height: 100px;
            width: 100%;
            float: left;
            background-image: url(/Image/userbg.jpg);
        }

        .userLayer_header_img {
            float: left;
            margin-left: 18px;
            margin-top: 19px;
            border: 1px solid #fff;
            border-radius: 3px;
        }

            .userLayer_header_img img {
                display: block;
                width: 60px;
                height: 60px;
            }

        .userLayer_header_font {
            float: left;
            margin-top: 40px;
            margin-left: 25px;
            font-size: 16px;
            color: #ebf2fa;
        }

        .userLayer_body {
            height: 120px;
            width: 100%;
            float: left;
            background-color: #ebf2fa;
            font-size: 12px;
            color: #121212;
        }

            .userLayer_body table {
                width: 100%;
                border: 0px;
                margin-top: 5px;
            }

                .userLayer_body table th {
                    height: 25px;
                    width: 60px;
                    text-align: right;
                }

                .userLayer_body table td {
                    text-align: left;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="userlayer">
            <div class="userLayer_header">
                <div class="userLayer_header_img">
                    <asp:Image ID="imgPic" runat="server" />
                </div>
                <div class="userLayer_header_font">
                    <asp:Label runat="server" ID="lbUserName1"></asp:Label>
                </div>
            </div>
            <div class="userLayer_body">
                <table>
                    <tr>
                        <th>姓名：</th>
                        <td>
                            <asp:Label runat="server" ID="lbUserName2"></asp:Label></td>
                    </tr>
                    <tr>
                        <th>手机：</th>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
