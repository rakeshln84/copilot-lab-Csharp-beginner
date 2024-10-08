using System;
using System.Collections.Generic;
using System.Linq;

namespace CopilotLab
{
    public class MusicStoreRepository
    {
        private List<Album> _albums;

        public MusicStoreRepository()
        {
            _albums = new List<Album>
                {
                    new Album(1, "The Dark Side of the Moon", "Pink Floyd", new DateTime(1973, 3, 1), new Genre(1, "Rock")),
                    new Album(2, "Thriller", "Michael Jackson", new DateTime(1982, 11, 30), new Genre(2, "Pop")),
                    new Album(3, "Kind of Blue", "Miles Davis", new DateTime(1959, 8, 17), new Genre(3, "Jazz")),
                    new Album(4, "Abbey Road", "The Beatles", new DateTime(1969, 9, 26), new Genre(1, "Rock")),
                };
        }

        public List<Album> GetAlbums()
        {
            return _albums;
        }

        public Album GetAlbum(int id)
        {
            return _albums.FirstOrDefault(a => a.Id == id);
        }

        public void AddAlbum(Album album)
        {
            if (!_albums.Any(a => a.Id == album.Id))
            {
                _albums.Add(album);
            }
            else
            {
                throw new DuplicateAlbumException("Album already exists.");
            }
        }

        public void UpdateAlbum(Album album)
        {
            var existingAlbum = _albums.FirstOrDefault(a => a.Id == album.Id);
            if (existingAlbum != null)
            {
                existingAlbum.Title = album.Title;
                existingAlbum.Artist = album.Artist;
                existingAlbum.ReleaseDate = album.ReleaseDate;
                existingAlbum.Genre = album.Genre;
            }
        }

        public void DeleteAlbum(int id)
        {
            var album = _albums.FirstOrDefault(a => a.Id == id);
            if (album != null)
            {
                _albums.Remove(album);
            }
        }

        public List<Album> SearchAlbumsByTitle(string title)
        {
            return _albums.Where(a => a.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Album> SearchAlbumsByArtist(string artist)
        {
            return _albums.Where(a => a.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Album> SearchAlbumsByGenre(string genre)
        {
            var genreId = _albums.FirstOrDefault(a => a.Genre.Name.Equals(genre, StringComparison.OrdinalIgnoreCase))?.Genre.Id;
            if (genreId != null)
                return _albums.Where(a => a.Genre.Id == genreId).ToList();
            return new List<Album>();
        }
    }
}
