using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Star_Light_Company.Pages
{

    public class unityModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        public List<string> assets = new List<string>();
        public string? folder;

        public unityModel(IWebHostEnvironment env)
        {
            _env = env;
        }
        public void OnGet()
        {
            string folderPath = Path.Combine(_env.WebRootPath, "Unity", "Assets");
            folder = folderPath;

            // 2. Kiểm tra nếu thư mục tồn tại để tránh lỗi gỡ lỗi
            if (Directory.Exists(folderPath))
            {
                // 3. Lấy danh sách tên file (ví dụ lọc file .unitypackage)
                var files = Directory.GetFiles(folderPath)
                                     .Select(Path.GetFileName)
                                     .ToList();
                assets = files!;
            }
        }
        public string GetFileUrl(string asset)
        {
            string path = Path.Combine(folder!, asset);
            return path;
        }
    }
}
