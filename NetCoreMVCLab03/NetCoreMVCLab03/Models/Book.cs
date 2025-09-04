using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetCoreMVCLab03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
    {
        new Book()
        {
            Id = 1,
            Title = "Chí Phèo",
            AuthorId = 1,
            GenreId = 1,
            Image = "/images/products/a1.jpg",
            Price = 500000,
            Sumary = "Tóm tắt về Chí Phèo...",
            TotalPage = 250
        },
        new Book()
        {
            Id = 2,
            Title = "Số Đỏ",
            AuthorId = 2,
            GenreId = 1,
            Image = "/images/products/a2.jpg",
            Price = 450000,
            Sumary = "Tóm tắt về Số Đỏ...",
            TotalPage = 300
        },
        new Book()
        {
            Id = 3,
            Title = "Lão Hạc",
            AuthorId = 1,
            GenreId = 1,
            Image = "/images/products/a3.jpg",
            Price = 300000,
            Sumary = "Tóm tắt về Lão Hạc...",
            TotalPage = 150
        },
        new Book()
        {
            Id = 4,
            Title = "Truyện Kiều",
            AuthorId = 3,
            GenreId = 2,
            Image = "/images/products/a4.jpg",
            Price = 600000,
            Sumary = "Tóm tắt về Truyện Kiều...",
            TotalPage = 500
        },
        new Book()
        {
            Id = 5,
            Title = "Dế Mèn Phiêu Lưu Ký",
            AuthorId = 4,
            GenreId = 3,
            Image = "/images/products/a5.jpg",
            Price = 350000,
            Sumary = "Tóm tắt về Dế Mèn Phiêu Lưu Ký...",
            TotalPage = 200
        }
    };

            return books;
        }
        public Book GetBookById(int Id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == Id);
            return book;
        }
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
             new SelectListItem {Value="1", Text="Nam cao"},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Adamkhoom"},
            new SelectListItem {Value="4", Text="Thiên sư Thích Nhất Hạnh"}
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
{
    new SelectListItem {Value="1", Text="Truyện tranh"},
    new SelectListItem {Value="2", Text="Văn học đương đại"},
    new SelectListItem {Value="3", Text="Phật học phổ thông"},
    new SelectListItem {Value="4", Text="Truyện cười"}
};
    }
}
