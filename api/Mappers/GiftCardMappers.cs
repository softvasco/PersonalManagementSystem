using api.Dtos.GiftCards;
using api.Helpers;
using api.Models;

namespace api.Mappers
{
    public static class GiftCardMappers
    {
        public static async Task<GiftCard> ToGiftCardFromCreateGiftCardDto(this CreateGiftCardDto createGiftCardDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (createGiftCardDto.File is not null)
                {
                    await createGiftCardDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new GiftCard
            {
                Code = createGiftCardDto.Code,
                Description = createGiftCardDto.Description,
                Balance = createGiftCardDto.Balance,
                OpenDate = createGiftCardDto.OpenDate,
                UserId = createGiftCardDto.UserId,
                Attachment = fileContent,
                FileName = createGiftCardDto.FileName,
                CardNumber = createGiftCardDto.CardNumber,
            };
        }

        public static GiftCardDto ToGiftCardDtoFromGiftCard(this GiftCard giftCard)
        {
            return new GiftCardDto
            {
                Id= giftCard.Id,
                Balance = giftCard.Balance,
                CardNumber = giftCard.CardNumber,
                Code = giftCard.Code,
                Description = giftCard.Description,
                OpenDate = giftCard.OpenDate,
                UserId = giftCard.UserId,
                FileBytes = giftCard.Attachment,
                FileName = giftCard.FileName,
                ContentType = giftCard.Attachment != null ? ByteArrayToFormFileExtensions.GetContentTypeFromExtension(ByteArrayToFormFileExtensions.InferFileExtension(giftCard.Attachment)) : string.Empty
            };
        }

        public static async Task<GiftCard> ToGiftCardFromUpdateGiftCardDto(this UpdateGiftCardDto updateGiftCardDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (updateGiftCardDto.File is not null)
                {
                    await updateGiftCardDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new GiftCard
            {
                Code = updateGiftCardDto.Code,
                Description = updateGiftCardDto.Description,
                Balance = updateGiftCardDto.Balance,
                OpenDate = updateGiftCardDto.OpenDate,
                UserId = updateGiftCardDto.UserId,
                Attachment = fileContent,
                CardNumber = updateGiftCardDto.CardNumber,
                FileName = updateGiftCardDto.FileName,
            };
        }

    }
}