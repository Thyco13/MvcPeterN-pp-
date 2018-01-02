using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Data.Entity;

namespace MvcPeterNäppä
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateFiles();
                
            }


        }

        private void PopulateFiles()
        {
            using (LinqToSQLclassDataContext dcContextc = new LinqToSQLclassDataContext())
            {
                List<UploadedFile> allFiles = dcContextc.UploadedFiles.ToList();
                DataList1.DataSource = allFiles;
                DataList1.DataBind();
                List<HiredbyUser> allHiredbyUsers = dcContextc.HiredbyUsers.ToList();
                DataList2.DataSource = allHiredbyUsers;
                DataList2.DataBind();
            }
        }

        protected void Uploadbtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                HttpPostedFile file = FileUpload1.PostedFile;
                BinaryReader br = new BinaryReader(file.InputStream);
                byte[] buffer = br.ReadBytes(file.ContentLength);

                using (LinqToSQLclassDataContext dc = new LinqToSQLclassDataContext())
                {
                    dc.UploadedFiles.InsertOnSubmit(
                        new UploadedFile
                        {
                            FileName = file.FileName,
                            ContentType = file.ContentType,
                            ID = 0,
                            FileSize = file.ContentLength,
                            FileExtension = Path.GetExtension(file.FileName),
                            FIleContent = buffer

                        });
                    dc.SubmitChanges();

                    PopulateFiles();
                }
            }
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
            if (e.CommandName == "Download")
            {
                
                int fileID = Convert.ToInt32((e.CommandArgument));
                using (LinqToSQLclassDataContext dc = new LinqToSQLclassDataContext())
                {
                    var v = dc.UploadedFiles.Where(a => a.ID.Equals(fileID)).FirstOrDefault();
                    if (v != null)
                    {
                        byte[] fileData = v.FIleContent.ToArray();
                        Response.AddHeader("Content type", v.ContentType);
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + v.FileName);
                        Response.AddHeader("ID", "ID" + v.ID);

                        byte[] datablock = new byte[0x1000];
                        long fileSize;
                        int byteRead;
                        long totalBytesRead = 0;

                        using (Stream st = new MemoryStream(fileData))
                        {
                            fileSize = st.Length;
                            while (totalBytesRead < fileSize)
                            {
                                if (Response.IsClientConnected)
                                {
                                    byteRead = st.Read(datablock, 0, datablock.Length);
                                    Response.OutputStream.Write(datablock, 0, byteRead);

                                    Response.Flush();
                                    totalBytesRead += byteRead;
                                }
                            }
                        }
                        
                        Response.End();
                    }

                    //HiredbyUser hiredbyUser = new HiredbyUser();
                    //hiredbyUser.UserName = Environment.UserName;
                    //hiredbyUser.HiredVideo = v.FileName;
                    //dc.HiredbyUsers.InsertOnSubmit(hiredbyUser);
                    //dc.SubmitChanges();
                    //PopulateFiles();

                }
            } 
        }

        protected void removebtn_Click(object sender, EventArgs e)
        {
            if (txtbxremove.Text != null)
            {
                int rowdelet = Convert.ToInt32(txtbxremove.Text);
                LinqToSQLclassDataContext dc = new LinqToSQLclassDataContext();

                var deletevideos = from finvid in dc.UploadedFiles
                    where finvid.ID == rowdelet
                    select finvid;


                foreach (var video in deletevideos)
                {
                    dc.UploadedFiles.DeleteOnSubmit(video);
                }

                dc.SubmitChanges();
                PopulateFiles();
            }
        }

        protected void DataList2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void DataList2_OnItemCommand(object source, DataListCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void lbtnDownload_OnClick(object sender, EventArgs e)
        {

            

            var v = Videonametodownload.Text;

            
            LinqToSQLclassDataContext dc = new LinqToSQLclassDataContext();
            
            HiredbyUser hiredbyUser = new HiredbyUser();
            hiredbyUser.UserName = Environment.UserName;
            hiredbyUser.HiredVideo = v;
            dc.HiredbyUsers.InsertOnSubmit(hiredbyUser);
            dc.SubmitChanges();
            PopulateFiles();
        }

        protected void VIdeotoDownload_Click(object sender, EventArgs e)
        {
            
            if (Videonametodownload != null )
            {
                
               DataList1.Visible = true;
                PopulateFiles();
                //DataList3.Visible = true;
            }
            else
            {
                Videonametodownload.Text = "You need to give a valid Video Name";
            }
            
        }

        protected void DataList3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {

                int fileID = Convert.ToInt32((e.CommandArgument));
                using (LinqToSQLclassDataContext dc = new LinqToSQLclassDataContext())
                {
                    var v = dc.UploadedFiles.Where(a => a.ID.Equals(fileID)).FirstOrDefault();
                    if (v != null)
                    {
                        byte[] fileData = v.FIleContent.ToArray();
                        Response.AddHeader("Content type", v.ContentType);
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + v.FileName);
                        Response.AddHeader("ID", "ID" + v.ID);

                        byte[] datablock = new byte[0x1000];
                        long fileSize;
                        int byteRead;
                        long totalBytesRead = 0;

                        using (Stream st = new MemoryStream(fileData))
                        {
                            fileSize = st.Length;
                            while (totalBytesRead < fileSize)
                            {
                                if (Response.IsClientConnected)
                                {
                                    byteRead = st.Read(datablock, 0, datablock.Length);
                                    Response.OutputStream.Write(datablock, 0, byteRead);

                                    Response.Flush();
                                    totalBytesRead += byteRead;
                                }
                            }
                        }

                        Response.End();
                    }

                    //HiredbyUser hiredbyUser = new HiredbyUser();
                    //hiredbyUser.UserName = Environment.UserName;
                    //hiredbyUser.HiredVideo = v.FileName;
                    //dc.HiredbyUsers.InsertOnSubmit(hiredbyUser);
                    //dc.SubmitChanges();
                    //PopulateFiles();

                }
            }
        }
    }
}