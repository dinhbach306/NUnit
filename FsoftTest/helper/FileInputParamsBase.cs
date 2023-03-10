using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FsoftTest.helper;

public class BaseDataSource<T> : IEnumerable
{
    protected virtual string DataFolder => "json";

    protected virtual string FileName => "base";

    private string GetFilePath()
    {
        var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directoryName == null)
            throw new Exception("Couldn't get assembly directory");

        return Path.Combine(directoryName, DataFolder, $"{FileName}.JSON");
    }

    public IEnumerator GetEnumerator()
    {
        var testFixtureParams = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(GetFilePath()))!;
        var genericItems = testFixtureParams[$"{typeof(T).Name}"]!.ToObject<IEnumerable<T>>()!;

        foreach (var item in genericItems)
        {
            yield return new object[] { item! };
        }
    }
}
