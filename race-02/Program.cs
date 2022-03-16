using System.Diagnostics;
using System.Text;

var test = () => {
    using var file = File.OpenText("/file/file.bin");
    var counter = 0;
    var sw = Stopwatch.StartNew();
    while(!file.EndOfStream)
    {
        if(file.Read() == '1')
        {
            counter++;
        }
    }
    sw.Stop();
    Console.WriteLine($"Counted {counter} 1s in {sw.Elapsed.TotalMilliseconds} milliseconds");
};

test();

var testAsync = async () =>
{
    using var sourceStream = new FileStream("/file/file.bin", FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
    var counter = 0;
    byte[] buffer = new byte[4096];
    var numRead = 0;
    var sw = Stopwatch.StartNew();
    while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
    {
        counter += buffer.Take(numRead).Count((x) => x == Encoding.UTF8.GetBytes("1")[0]);
    }
    sw.Stop();
    Console.WriteLine($"Counted {counter:N} 1s in {sw.Elapsed.TotalMilliseconds} milliseconds");
};

//await testAsync();