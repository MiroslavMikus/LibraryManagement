using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;

namespace LibraryManagement.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context) { }
    }
}
