using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;





// tạo dối tượng dbcontext để quản lý phiên làm việc
// với CSDL và trạng thái của các đối tượng
var context = new BlogDbContext();


//đọc danh sách các bài viết từ cở sở dữ liệu
// Lấy kèm tên các tác giả & chuyên mục

//Xuat danh sach ra man hinh
var posts = context.Posts
    .Where(p => p.Published)
    .OrderBy(p => p.Title)
    .Select(p => new
    {
        Id = p.Id,
        Title = p.Title,
        ViewCount = p.ViewCount,
        PostedDate = p.PostedDate,
        Author = p.Author.FullName,
        Category = p.Category.Name
    })
    .ToList();

//Xuất danh sách các bài viết ra màn hình

foreach (var post in posts)
{
    Console.WriteLine("ID           :{0}",post.Id);
    Console.WriteLine("Title        :{0}",post.Title);
    Console.WriteLine("View         :{0}",post.ViewCount);
    Console.WriteLine("Date         :{0:MM/dd/yyyy}",post.PostedDate);
    Console.WriteLine("Author       :{0}",post.Author);
    Console.WriteLine("Category     :{0}",post.Category);
    Console.WriteLine("".PadRight(80, '-'));
}

//(1)
//var seeder = new DataSeeder(context);

//seeder.Initialize();

//var authors = context.Authors.ToList();

//Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12}",
//    "ID","Full Name","Email","Joined Date");

//foreach (var author in authors)
//{
//    Console.WriteLine("{0,-4}{1,-30}{2,-30}{3,12:MM/dd/yyyy}",
//        author.Id,author.FullName,author.Email,author.JoinedDate);
//}
