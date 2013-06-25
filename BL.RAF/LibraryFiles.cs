using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.RAF
{
    /// <summary>
    /// LibraryFiles
    /// </summary>
    public class LibraryFiles : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LibraryFiles()
            : base("LIBRARY_FILES")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LibraryFiles(DataSet data)
            : base(data, "LIBRARY_FILES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LibraryTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="description">description</param>
        /// <param name="originalFileName">originalFileName</param>
        /// <param name="thumbnailFileName">thumbnailFileName</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fileSize">fileSize</param>
        public void Insert(string fileName, string description, string originalFileName, string thumbnailFileName, int libraryCategoriesId, int loginId, int companyId, string fileSize)
        {
            LibraryTDS.LIBRARY_FILESRow libraryFilesRow = ((LibraryTDS.LIBRARY_FILESDataTable)Table).NewLIBRARY_FILESRow();
            libraryFilesRow.FILENAME = fileName;
            libraryFilesRow.DESCRIPTION = description;
            libraryFilesRow.ORIGINAL_FILENAME = originalFileName;
            libraryFilesRow.THUMBNAIL_FILENAME = thumbnailFileName;
            if (libraryCategoriesId != 0) libraryFilesRow.LIBRARY_CATEGORIES_ID = libraryCategoriesId; else libraryFilesRow.SetLIBRARY_CATEGORIES_IDNull(); 
            libraryFilesRow.LOGIN_ID = loginId;
            libraryFilesRow.COMPANY_ID = companyId;
            libraryFilesRow.FILE_SIZE = fileSize;
            libraryFilesRow.ACTIVE = true;
            libraryFilesRow.DATE_TIME = DateTime.Now;
            
            ((LibraryTDS.LIBRARY_FILESDataTable)Table).AddLIBRARY_FILESRow(libraryFilesRow);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        public void Delete(int libraryFilesId)
        {
            LibraryTDS.LIBRARY_FILESRow lfsFilesIdRow = GetRow(libraryFilesId);
            lfsFilesIdRow.ACTIVE = false;
        }



                

        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <returns>LibraryTDS.LIBRARY_FILESRow</returns>
        private LibraryTDS.LIBRARY_FILESRow GetRow(int libraryFilesId)
        {
            LibraryTDS.LIBRARY_FILESRow row = ((LibraryTDS.LIBRARY_FILESDataTable)Table).FindByLIBRARY_FILES_ID(libraryFilesId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.RAF.LibraryFiles.GetRow");
            }

            return row;

        }



    }
}