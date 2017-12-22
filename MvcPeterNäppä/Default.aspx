<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MvcPeterNäppä._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <BODY>
    
    <H3>File upload / Download from/to database</h3>
    <DIV>
        <TABLE>
            <TR>
                <TD style="width: 220px">Select File:</td>
                <TD>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                     

                </td>
                <tr>
                <td style="width: 220px">
                    <asp:Button ID="Uploadbtn" runat="server" Text="Upload" OnClick="Uploadbtn_Click" />
                    <BR />
                    <asp:Label ID="Label2" runat="server" Text="Label">Click Browse and choose a video to upload and the click Upload</asp:Label>
                    <br />
                 
                </td>
            </tr>
            <br />
            <br />
            <TR>
                <br />
                <TD style="width: 220px"><asp:Button ID="removebtn" runat="server" Text="Remove" OnClick="removebtn_Click" /> <asp:TextBox ID="txtbxremove" runat="server"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="Label">Write the ID number of the video you want to remove</asp:Label>
                </td>
            </tr>
        </table>
        <BR/>
        <asp:Button ID="VIdeotoDownload" runat="server" Text="Enable Download" OnClick="VIdeotoDownload_Click" />
&nbsp;<asp:TextBox ID="Videonametodownload" runat="server"></asp:TextBox> <LABEL>Write the name of the video you want to rent and then click Enable Download, &nbsp; 
        <BR />
        Then click the download link under the chosen video</label>
        <BR/>
       <%-- <asp:DataList ID="DataList3" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList3_SelectedIndexChanged" OnItemCommand="DataList3_ItemCommand" Visible="True">
            <ItemTemplate>
                <TABLE>
                    <TR><%#Eval("ID") %></tr>
                    <TR>
                        <TD><%#Eval("FileName","File Name : {0}") %></td>
                    </tr>
                    <TR>
                        <TD><%#String.Format("{0:0.00}",Convert.ToDecimal(Eval("FileSize"))/1024) %>KB</td>
                    </tr>   
                </table>
            </ItemTemplate>
        </asp:DataList>--%>
        <BR/>
        <BR/>
        <asp:Label ID="Label4" runat="server" Text="Label">Uploaded Videos</asp:Label>
        <DIV>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand" Visible="True">
                <ItemTemplate>
                    <TABLE>
                        <TR><%#Eval("ID") %></tr>
                        <TR>
                            <TD><%#Eval("FileName","File Name : {0}") %></td>
                        </tr>
                        <TR>
                            <TD><%#String.Format("{0:0.00}",Convert.ToDecimal(Eval("FileSize"))/1024) %>KB</td>
                        </tr>
                        <TR>
                            <TD><asp:LinkButton ID="lbtnDownload" runat="server" OnClick="lbtnDownload_OnClick" CommandName="Download" CommandArgument=<%#Eval("ID") %> Visible="True">Download</asp:LinkButton></td>
                            
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <BR/> <BR/>

            <asp:Label ID="Label3" runat="server" Text="Label">VIdeos hired by User</asp:Label>
            

            <BR/>
        </div>
        <asp:DataList ID="DataList2" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList2_OnSelectedIndexChanged" OnItemCommand="DataList2_OnItemCommand">
            <ItemTemplate>
                <TABLE>
                    <TR>
                        <TD><%#Eval("ID") %></td></tr>
                    <TR><TD><%#Eval("UserName","User Name: {0}") %></td></tr>
                    <TR><TD><%#Eval("HiredVideo","File Name : {0}") %></td></tr>

                </table>
            </ItemTemplate>
        </asp:DataList>
               <%-- <asp:DataList runat="server" id="IDUser">
                    <ItemTemplate>
                <TABLE runat="server" RepeatColumns="4" RepeatDirection="Horizontal" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand">
                    <TR>
                        <TD>User who hired:</td>
                        <TD><asp:Label  runat="server" Text=""></asp:Label></TD>
                        <TD><%#Eval("FileName","File Name : {0}")%></td>
                    </tr>
                </TABLE>
                    </ItemTemplate>
                </asp:DataList>--%>

    </div>
    </body>
</asp:Content>
