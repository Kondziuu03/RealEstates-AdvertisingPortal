﻿namespace RealEstates.Application.Common.Interfaces;
public interface IEmail
{
    Task Update(IAppSettingsService appSettingsService);
    Task SendAsync(string subject, string body, string to, string attachmentPath = null);
}