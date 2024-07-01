namespace QuanLyThuVien.Models
{
    public class CurrentUser
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        // Add these new properties
        public string MaTK { get; set; }
        public string LoaiTK { get; set; }
    }
}
