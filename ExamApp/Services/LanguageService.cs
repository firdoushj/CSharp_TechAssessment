using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamApp.Context;

namespace ExamApp.Services;

public class LanguageService
{
    public IAsyncEnumerable<Language> GetLanguages()
    {
        var ctx = new MainContext();

        return ctx.Languages.AsAsyncEnumerable();
    }

    public async Task AddLanguages()
    {
        var db = new MainContext();

        for (var i = 0; i < 10; i++)
        {
            db.Languages.Add(new Language(Guid.NewGuid(), $"Lang {i}"));
        }

        await db.SaveChangesAsync();
    }
}