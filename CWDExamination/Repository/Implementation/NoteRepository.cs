using CWDExamination.Models;
using CWDExamination.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWDExamination.Repository.Implementation
{
    public class NoteRepository:INoteRepository<Note>
    {
        readonly ApplicationDbContext db;

        public NoteRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Note> GetAllNote()
        {
            return db.Notes.ToList();
        }

        public Note PostNote(Note note)
        {
            try
            {
                if (db != null)
                {
                    db.Add(note);
                    db.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log exception  
                return null;
            }
        }

        public Note GetNote(int Id)
        {
            try
            {
                return db.Notes.Where(e => e.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log exception  
                return null;
            }
        }

        public Note UpdateNote(Note note)
        {
            try
            {
                if (db != null)
                {
                    db.Update(note);
                    db.SaveChanges();
                    return note;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log exception  
                return null;
            }
        }

        public int DeleteNote(int Id)
        {
            try
            {
                if (db != null)
                {
                    var note = db.Notes.FirstOrDefault(x => x.Id == Id);
                    if (note != null)
                    {
                        db.Notes.Remove(note);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                //log exception  
                return 0;
            }
        }
    }
}
