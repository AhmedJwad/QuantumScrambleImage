namespace QuantumScrambleImage.Helpers
{
    public interface IBlobHelper
    {
        Task<String> UploadBlobAsync(IFormFile imageFile, string containerName);

        Task<String> UploadBlobAsync(byte[] imageFile, string containerName);

        Task<String> UploadBlobAsync(string imageFile, string containerName);

        Task DeleteBlobAsync(string id, string containerName);

    }
}
