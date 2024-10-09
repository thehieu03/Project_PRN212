using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? BookImg { get; set; }

    public string? BookDescription { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<BookBorrowingRegistrationForm> BookBorrowingRegistrationForms { get; set; } = new List<BookBorrowingRegistrationForm>();
}
