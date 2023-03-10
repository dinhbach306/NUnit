namespace FsoftTest.helper;

public class FileInputSource<T> : BaseDataSource<T>
{
    // You may want to override the base file and sub folder like so. Note the .json will be added to the filename
    
    protected override string FileName => "MemberInputParam";  
    // protected override string DataFilesSubFolder => "CRUDTesting-main/FsoftTest/json";
}