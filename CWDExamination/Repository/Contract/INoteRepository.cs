using CWDExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWDExamination.Repository.Contract
{
    public interface INoteRepository<T>
    {
            IEnumerable<T> GetAllNote();
        Note PostNote(Note saveNote);
        Note GetNote(int id);
        Note UpdateNote(Note savedNote);
        int DeleteNote(int id);
        //PostNote(Note note);
    }
}
