using Dtos;
using Dtos.Kategori;
using Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface IAppRepository
    {
        //Returning as an object.
        List<HaberDTO> GetAllHaber();
        HaberDTO GetHaber(int id);
        List<KategoriDTO> GetAllKategori();
        KategoriDTO GetKategori(int id);
        List<CommentDTO> GetAllComment();
        List<CommentDTO> GetCommentByHaber(int haberID);
        CommentDTO GetComment(int id);

        //Haber
        void AddHaber(AddHaberDTO haber);
        void AddKategori(AddKategoriDTO kategori);
        void DeleteHaber(HaberDTO haber);
        void UpdateHaber(int id, HaberDTO newhaber);

        //Kategori
        void DeleteKategori(Kategori kategori);
        void UpdateKategori(int id, Kategori newkategori);

        //Comment
        void AddComment(AddCommentDTO comment);
        void DeleteComment(int id);
        void UpdateComment(int id, CommentDTO comment);

    }
}
