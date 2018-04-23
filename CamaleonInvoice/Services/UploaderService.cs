using System;
using System.Threading.Tasks;
using Dropbox.Api;
using System.Text;
using Dropbox.Api.Files;
using System.IO;

public class UploaderService
{
    private DropboxClient dbx;

    public UploaderService()
    {
        var task = Task.Run((Func<Task>)UploaderService.Run);
        task.Wait();

        Upload(
           new DropboxClient("gz-S-0uKs5cAAAAAAAAsaBioEFkmuSwCLBXGmQcCiiPUs2S6xlWWW_LJiKhq-rb4"),

            @"/XML",
            "20527398372-03-B001-00009193.xml",
            "primera subida"

            ).Wait();
    }

    public static async Task Run()
    {
        using (var dbx = new DropboxClient("gz-S-0uKs5cAAAAAAAAsaBioEFkmuSwCLBXGmQcCiiPUs2S6xlWWW_LJiKhq-rb4"))
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
        }
    }

    private async Task Upload(DropboxClient dbx, string folder, string file, string content)
    {
        using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
        {
            var updated = await dbx.Files.UploadAsync(
                folder + "/" + file,
                WriteMode.Overwrite.Instance,
                body: mem);

            Console.WriteLine("Saved {0}/{1} rev {2}", folder, file, updated.Rev);
        }
        var slink = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(folder + "/" + file, null);
        Console.WriteLine(slink.Url);
    }
}