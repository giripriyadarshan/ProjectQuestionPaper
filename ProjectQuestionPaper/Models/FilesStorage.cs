using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ProjectQuestionPaper.Models
{
    public class FilesStorage
    {
        private static readonly StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        public static async Task<StorageFolder> CreateSubFolderAsync(string subFolderName)
        {
            return await localFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.OpenIfExists);
        }

        public static async Task<StorageFolder> GetSubFolderAsync(string subFolderName)
        {
            return await localFolder.GetFolderAsync(subFolderName);
        }

        /*
         
            When add contents
            * Create sub-folder with yearId in local folder
            * if (file already exists)
                * replace if requested
                    * Get file from sub-folder
            * if (file doesn't exist)
                * copy the file to local folder
                
            When delete contents
            * Get file from sub-folder
            * Delete the file
            * Delete the sub-folder if necessary
            
            When need to open file
            * Get file from sub-folder
            * extract path and launch/open the file
            
         */

    }
}
