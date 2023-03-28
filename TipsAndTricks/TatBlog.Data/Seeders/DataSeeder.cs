﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Data.Contexts;
using TatBlog.Core.Entities;

namespace TatBlog.Data.Seeders;

public class DataSeeder : IDataSeeder
{
    private readonly BlogDbContext _dbContext;
    public DataSeeder(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Initialize()
    {
        _dbContext.Database.EnsureCreated();

        if (_dbContext.Posts.Any()) return;

        var authors = AddAuthors();
        var categories = AddCategories();
        var tags = AddTags();
        var posts = AddPosts(authors, categories, tags);
    }


    private IList<Author> AddAuthors()
    {
        var authors = new List<Author>()
        {
            new()
            {
                FullName = "Jason Mouth",
                UrlSlug = "jason-mouth",
                Email ="json@gmail.com",
                JoinedDate = new DateTime(2022,10,21)
            },
            new()
            {
                FullName = "Jessica Wonder",
                UrlSlug = "jessica-wonder",
                Email ="jessica665@gmail.com",
                JoinedDate = new DateTime(2020,4,19)
            },
            new()
            {
                FullName = "Nguyen Le Thanh Tinh",
                    UrlSlug="nguyen-le-thanh-tinh",
                    Email="2012384@dlu.edu.vn",
                    JoinedDate=new DateTime(2021,2,28)
            },
             new()
            {
                FullName = "Nguyen Thanh Long",
                    UrlSlug="nguyen-thanh-long",
                    Email="longnt@dlu.edu.vn",
                    JoinedDate=new DateTime(2023,1,8)
            }
        };


        _dbContext.Authors.AddRange(authors);
        _dbContext.SaveChanges();

        return authors;
    }
    private IList<Category> AddCategories()
    {
        var categories = new List<Category>()
            {
                new() { Name =".Net Core", Description =".Net Core", UrlSlug = "net-core", ShowOnMenu = true, Posts = new List<Post>(){ } },
                new() { Name ="Architecture", Description ="Architecture", UrlSlug = "architecture", ShowOnMenu = true, Posts = new List<Post>(){ } },
                new() { Name ="Messaging", Description ="Messaging", UrlSlug = "messaging", ShowOnMenu = true, Posts = new List<Post>(){ } },
                new() { Name ="OOP", Description ="OOP", UrlSlug = "oop", ShowOnMenu = true, Posts = new List<Post>(){ } },
                new() { Name ="Design Patterns", Description ="Design Patterns", UrlSlug = "design-patterns", ShowOnMenu = true, Posts = new List<Post>(){ } },
                new() { Name ="Architecture", Description ="Architecture", UrlSlug = "architecture", ShowOnMenu = true},
                new() { Name ="C Sharp", Description ="c-sharp", UrlSlug = "csharp", ShowOnMenu = true},
                new() { Name ="Java", Description ="Java", UrlSlug = "java", ShowOnMenu = true},
                new() { Name ="Workpress", Description ="Workpress", UrlSlug = "workpress", ShowOnMenu = true},
                new() { Name ="Golang", Description ="Golang", UrlSlug = "golang", ShowOnMenu = true },
                new() { Name ="Ruby", Description ="Ruby", UrlSlug = "ruby", ShowOnMenu = true},
                new() { Name ="C Sharp", Description ="C Sharp", UrlSlug = "csharp", ShowOnMenu = true},
                new() { Name ="PHP", Description ="PHP", UrlSlug = "php", ShowOnMenu = true},
                new() { Name ="Dart", Description ="Dart", UrlSlug = "dart", ShowOnMenu = true},
                new() { Name ="JavaScript", Description ="JavaScript", UrlSlug = "javascript", ShowOnMenu = true}
            };
        _dbContext.AddRange(categories);
        _dbContext.SaveChanges();
        return categories;
    }
    private IList<Tag> AddTags()
    {
        var tags = new List<Tag>()
            {
                new() {Name = "AI", Description = "AI Assistant", UrlSlug="GPT-applications", Posts = new List<Post>(){  }},
                new() {Name = "ASP.NET MVC", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){  }},
                new() {Name = "Python", Description = "Python applications", UrlSlug="python-applications", Posts = new List<Post>(){  }},
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){  }},
                new() {Name = "Google", Description = "Google applications", UrlSlug="google-applications", Posts = new List<Post>(){  }},
                new() { Name ="Architecture", Description ="Architecture", UrlSlug = "architecture", Posts = new List<Post>(){  }},
                new() { Name ="C Sharp", Description ="c-sharp", UrlSlug = "csharp", Posts = new List<Post>(){  }},
                new() { Name ="Java", Description ="Java", UrlSlug = "java", Posts = new List<Post>(){  }},
                new() { Name ="Workpress", Description ="Workpress", UrlSlug = "workpress",Posts = new List<Post>(){  }},
                new() { Name ="Golang", Description ="Golang", UrlSlug = "golang",Posts = new List<Post>(){  }},
                new() { Name ="Ruby", Description ="Ruby", UrlSlug = "ruby", Posts = new List<Post>(){  }},
                new() { Name ="C Sharp", Description ="C Sharp", UrlSlug = "csharp",Posts = new List<Post>(){  }},
                new() { Name ="PHP", Description ="PHP", UrlSlug = "php", Posts = new List<Post>(){  }},
                new() { Name ="Dart", Description ="Dart", UrlSlug = "dart",Posts = new List<Post>(){  }},
                new() { Name ="JavaScript", Description ="JavaScript", UrlSlug = "javascript", Posts = new List<Post>(){  }},
            };
        _dbContext.AddRange(tags);
        _dbContext.SaveChanges();
        return tags;
    }

    private IList<Post> AddPosts(
        IList<Author> authors,
        IList<Category> categories,
        IList<Tag> tags)
    {
        var posts = new List<Post>()
        {
            new()
            {
                Title = "ASP.NET Core Diagnostic Scenarios",
                ShortDescription = "David and friends has a great repos",
                Description = "Here's a few great DON'T and DO examples",
                Meta = "David and friends has a great respensitory filled",
                UrlSlug = "aspnet-core-diagnostic-scenarios",
                Published = true,
                PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                ModifiedDate = null,
                ViewCount = 10,
                Author = authors[0],
                Category = categories[0],
                Tags = new List<Tag>()
                {
                    tags[0]
                }

            },
            new()
                {
                    Title ="Vietnam Post English Club",
                    ShortDescription = "Vietnam Post English Club was established and operated by the Standing Committee chaired by Mr. Pham Anh Tuan – Chairman of Vietnam Post",
                    Description = "On 7th April 2018, Vietnam Post opened its English Club with the objectives to improve English skills for all staff and employees",
                    Meta = "Vietnam Post English Club",
                    UrlSlug = "Vietnam-Post-English-Club",
                    Published = true,
                    PostedDate = new DateTime(2018,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 20,
                    Author = authors[1],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                new()
                {
                    Title ="Google",
                    ShortDescription = "công cụ tìm kiếm phổ biến nhất chiếm hơn 90% thị trường trên toàn thế giới",
                    Description = "Google còn tự hào về các tính năng nổi bật khiến nó trở thành công cụ tìm kiếm tốt nhất trên thị trường",
                    Meta = "nó tự hào có các thuật toán tiên tiến, giao diện dễ sử dụng",
                    UrlSlug = "google",
                    Published = true,
                    PostedDate = new DateTime(2009,9,3,1,2,0),
                    ModifiedDate = null,
                    ViewCount = 15,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },
                new()
                {
                    Title ="ASP.NET Core Diagnostic Scenarios",
                    ShortDescription = "David and friends has a great repos",
                    Description = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repos",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                new()
                {
                    Title ="ASP.NET Core Diagnostic Scenarios",
                    ShortDescription = "David and friends has a great repos",
                    Description = "Here's a few great DON'T and DO examples",
                    Meta = "David and friends has a great repos",
                    UrlSlug = "aspnet-core-diagnostic-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021,9,30,10,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                new()
                {
                    Title ="Ruby",
                    ShortDescription = "At GemSelect we sell natural Rubies from many different locations like Burma, Madagascar, Mozambique and Thailand.",
                    Description = "We carry popular shapes and sizes which are suitable for all kinds of jewelry.",
                    Meta = "We sell only natural Rubies and offer certification from well known gemological labs like ICA Gemlab and AIG Gemlab.",
                    UrlSlug = "gemselect",
                    Published = true,
                    PostedDate = new DateTime(2011,8,30,1,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                new()
                {
                    Title ="Google",
                    ShortDescription = "công cụ tìm kiếm phổ biến nhất chiếm hơn 90% thị trường trên toàn thế giới",
                    Description = "Google còn tự hào về các tính năng nổi bật khiến nó trở thành công cụ tìm kiếm tốt nhất trên thị trường",
                    Meta = "nó tự hào có các thuật toán tiên tiến, giao diện dễ sử dụng",
                    UrlSlug = "google",
                    Published = true,
                    PostedDate = new DateTime(2009,9,3,1,2,0),
                    ModifiedDate = null,
                    ViewCount = 15,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },
                new()
                {
                    Title ="Google",
                    ShortDescription = "công cụ tìm kiếm phổ biến nhất chiếm hơn 90% thị trường trên toàn thế giới",
                    Description = "Google còn tự hào về các tính năng nổi bật khiến nó trở thành công cụ tìm kiếm tốt nhất trên thị trường",
                    Meta = "nó tự hào có các thuật toán tiên tiến, giao diện dễ sử dụng",
                    UrlSlug = "google",
                    Published = true,
                    PostedDate = new DateTime(2009,9,3,1,2,0),
                    ModifiedDate = null,
                    ViewCount = 15,
                    Author = authors[3],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },
                new()
                {
                    Title ="Ruby",
                    ShortDescription = "At GemSelect we sell natural Rubies from many different locations like Burma, Madagascar, Mozambique and Thailand.",
                    Description = "We carry popular shapes and sizes which are suitable for all kinds of jewelry.",
                    Meta = "We sell only natural Rubies and offer certification from well known gemological labs like ICA Gemlab and AIG Gemlab.",
                    UrlSlug = "gemselect",
                    Published = true,
                    PostedDate = new DateTime(2011,8,30,1,20,0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                }
        };

        _dbContext.AddRange(posts);
        _dbContext.SaveChanges();
        return posts;
    }

}
