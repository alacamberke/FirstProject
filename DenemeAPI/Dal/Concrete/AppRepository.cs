using Dal.Abstract;
using Dtos;
using Dtos.Kategori;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete
{
    public class AppRepository : IAppRepository
    {
        private Context _context;
        public AppRepository(Context context)
        {
            _context = context;
        }

        public void AddHaber(AddHaberDTO haber)
        {
            var kategori = _context.Kategoris
                .Where(i => i.KategoriId == haber.KategoriID).FirstOrDefault();
            var entity = new Haber();
            entity.HaberName = haber.HaberName;
            entity.HaberOwner = haber.HaberOwner;
            entity.HaberDescription = haber.HaberDescription;
            entity.KategoriId = kategori.KategoriId;
            _context.Habers.Add(entity);
            _context.SaveChanges();
        }

        public void AddKategori(AddKategoriDTO kategoridto)
        {
            var kategori = new Kategori();
            kategori.KategoriName = kategoridto.KategoriName;
            _context.Kategoris.Add(kategori);
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteHaber(HaberDTO haber)
        {
            var entity = _context.Habers
                .Where(i => i.HaberName == haber.HaberName).FirstOrDefault();
            _context.Habers.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteKategori(Kategori kategori)
        {
            _context.Kategoris.Remove(kategori);
            _context.SaveChanges();
        }

        public List<CommentDTO> GetAllComment()
        {
            var comments = _context.Comments
                .Select(i => new CommentDTO
                {
                    CommentDescription = i.CommentDescription,
                    CommentOwner = i.CommentOwner,
                    HaberName = i.Haber.HaberName
                }).ToList();
            return comments;
        }

        public List<HaberDTO> GetAllHaber()
        {
            var habers = _context.Habers
                .Select(i => new HaberDTO
                {
                    HaberName = i.HaberName,
                    HaberDescription = i.HaberDescription,
                    HaberOwner = i.HaberOwner,
                    KategoriName = i.kategori.KategoriName
                }).ToList();

            return habers;
        }

        public List<KategoriDTO> GetAllKategori()
        {
            var kategoris = _context.Kategoris.Select(i=>new KategoriDTO 
            {
                KategoriName = i.KategoriName,
                Habers = i.Habers
            }).ToList();
            return kategoris;
        }

        public CommentDTO GetComment(int id)
        {
            var comment = _context.Comments.Find(id);
            var dto = new CommentDTO();
            dto.CommentDescription = comment.CommentDescription;
            dto.CommentOwner = comment.CommentOwner;
            dto.HaberName = comment.Haber.HaberName;

            return dto;
        }

        public List<CommentDTO> GetCommentByHaber(int haberID)
        {
            var comments = _context.Comments.Where(i => i.HaberId == haberID)
                .Select(i => new CommentDTO
                {
                    CommentDescription = i.CommentDescription,
                    CommentOwner = i.CommentOwner,
                    HaberName = i.Haber.HaberName

                }).ToList();

            return comments;
        }

        public void AddComment(AddCommentDTO commentdto)
        {
            Comment comment = new Comment();
            comment.CommentDescription = commentdto.CommentDescription;
            comment.CommentOwner = commentdto.CommentOwner;
            comment.HaberId = commentdto.HaberId;
            comment.IsConfirmed = false;

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public HaberDTO GetHaber(int id)
        {
            var haber = _context.Habers.Find(id);
            if(haber == null)
            {
                return null;
            }

            var haberkategori = _context.Kategoris.Find(haber.KategoriId);
            var dto = new HaberDTO();
                dto.KategoriName = haberkategori.KategoriName;
                dto.HaberName = haber.HaberName;
                dto.HaberOwner = haber.HaberOwner;
                dto.HaberDescription = haber.HaberDescription;
            return dto;
        }

        public KategoriDTO GetKategori(int id)
        {
            var kategori = _context.Kategoris.Find(id);
            var dto = new KategoriDTO();
            dto.KategoriName = kategori.KategoriName;
            return dto;
        }

        public void UpdateComment(int id, CommentDTO comment)
        {
            throw new NotImplementedException();
        }

        public void UpdateHaber(int id, HaberDTO newhaber)
        {
            var kategori = _context.Kategoris.Where(i => i.KategoriName == newhaber.KategoriName).FirstOrDefault();
            var haber = _context.Habers.Find(id);
            haber.HaberName = newhaber.HaberName;
            haber.HaberDescription = newhaber.HaberDescription;
            haber.HaberOwner = newhaber.HaberOwner;
            haber.KategoriId = kategori.KategoriId;
            haber.Confirmation = false;
            _context.SaveChanges();
        }

        public void UpdateKategori(int id, Kategori newkategori)
        {
            var kategori = _context.Kategoris.Find(id);
            kategori.KategoriName = newkategori.KategoriName;
            _context.SaveChanges();
        }
    }
}
