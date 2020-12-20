﻿using MyBooksStore.Data;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public int AddBook(BookModel bookModel)
        {
            var newBook = new Books() {
                Title = bookModel.Title,
                Author =bookModel.Author,
                Description=bookModel.Description,
                TotalPages=bookModel.TotalPages,
                CreatedOn=DateTime.UtcNow,
                UpdatedOn=DateTime.UtcNow
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(b => b.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title , string author)
        {
            return DataSource().Where(b => b.Title.Contains(title) || b.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>() { 
                new BookModel(){Id=1 , Title="C" , Author="sangram" , Description="This is C Description.", Category="Programming" , Language="English" , TotalPages=100},
                new BookModel(){ Id=2 , Title="C++" , Author="ritesh" , Description="This is C++ Description.",Category="Programming" , Language="English" , TotalPages=120},
                new BookModel(){ Id=3 , Title="C#" , Author="happy" , Description="This is C# Description.",Category="Programming" , Language="English" , TotalPages=150},
                new BookModel(){ Id=4 , Title="Python" , Author="Pravin" , Description="This is Python Description.",Category="Programming" , Language="English" , TotalPages=200}
            };
        }
    }
}
