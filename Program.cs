using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("© CombineSupremacy 2026");

        if (args.Length == 0)
        {
            Console.WriteLine("Drag a PNG file onto this executable.\nPress any key to exit.");
            Console.ReadLine();
            return;
        }

        string path = args[0];

        if (!File.Exists(path) || Path.GetExtension(path).ToLower() != ".png")
        {
            Console.WriteLine("Only PNG files are supported.\nPress any key to exit.");
            Console.ReadLine();
            return;
        }

        ProcessImage(path);
    }

    static void ProcessImage(string path)
    {
        using Image<Rgba32> image = SixLabors.ImageSharp.Image.Load<Rgba32>(path);

        if (image.Width > 1024 || image.Height > 1024)
        {
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(1024, 1024)
            }));
        }

        using Image<Rgba32> ao = new(image.Width, image.Height);
        using Image<Rgba32> roughness = new(image.Width, image.Height);
        using Image<Rgba32> metallic = new(image.Width, image.Height);

        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                Rgba32 pixel = image[x, y];
                ao[x, y] = new Rgba32(pixel.R, pixel.R, pixel.R);
                roughness[x, y] = new Rgba32(pixel.G, pixel.G, pixel.G);
                metallic[x, y] = new Rgba32(pixel.B, pixel.B, pixel.B);
            }
        }

        string directory = Path.GetDirectoryName(path)!;
        string OriginalFilename = Path.GetFileNameWithoutExtension(path);

        string[] parts = OriginalFilename.Split("_");

        OriginalFilename = string.Join("_", parts.Take(3));

        ao.Save(Path.Combine(directory, OriginalFilename + "_ao.png"));
        roughness.Save(Path.Combine(directory, OriginalFilename + "_roughness.png"));
        metallic.Save(Path.Combine(directory, OriginalFilename + "_metallic.png"));

        Console.WriteLine("AO, Roughness, and Metallic maps generated successfully.");
    }
}
