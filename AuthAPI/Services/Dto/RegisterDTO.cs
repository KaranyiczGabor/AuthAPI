namespace AuthAPI.Services.Dto
{
    public record RegisterRequestDto(string Username, string Password, string Email, DateTime BirthDate);
}
