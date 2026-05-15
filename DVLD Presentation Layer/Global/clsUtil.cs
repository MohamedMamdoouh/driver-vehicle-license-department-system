using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Global
{
    public class clsUtil
    {
        public static clsUser CurrentUser;

        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            FileInfo fi = new FileInfo(SourceFile);
            return GenerateGUID() + fi.Extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\Users\Mohamed Mamdouh\Desktop\Project\DVLD Project\People Images\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }
    }
}