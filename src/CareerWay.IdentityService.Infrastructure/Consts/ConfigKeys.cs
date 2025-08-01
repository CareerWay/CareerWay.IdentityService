﻿namespace CareerWay.IdentityService.Infrastructure.Consts;

public static class ConfigKeys
{
    public static class AzureKeyVault
    {
        public const string Uri = "AzureKeyVaultOptions:Uri";
        public const string TenantId = "AzureKeyVaultOptions:TenantId";
        public const string ClientId = "AzureKeyVaultOptions:ClientId";
        public const string ClientSecret = "AzureKeyVaultOptions:ClientSecret";
    }

    public static class Security
    {
        public const string Issuer = "AccessTokenOptions:Issuer";
        public const string Audience = "AccessTokenOptions:Audience";
        public const string Expiration = "AccessTokenOptions:Expiration";
        public const string SecurityKey = "AccessTokenSecurityKey";
    }

    public static class CareerWayServices
    {
        public const string BaseUrl = "CareerWayServices:BaseUrl";
        public const string JobSeekerServiceUrl = "CareerWayServices:JobSeekerServiceUrl";
        public const string CompanyServiceUrl = "CareerWayServices:CompanyServiceUrl";
    }

    public static class AzureSQL
    {
        public const string ConnectionString = "IdentityServiceAzureSQLConnectionString";
    }

    public static class Seq
    {
        public const string ConnectionString = "SeqConnectionString";
    }

    public static class Kafka
    {
        public const string ProducerBootstrapServers = "KafkaProducerBootstrapServers";
        public const string ProducerSaslUsername = "KafkaProducerSaslUsername";
        public const string ProducerSaslPassword = "KafkaProducerSaslPassword";

        public const string ConsumerBootstrapServers = "KafkaConsumerBootstrapServers";
        public const string ConsumerSaslUsername = "KafkaConsumerSaslUsername";
        public const string ConsumerSaslPassword = "KafkaConsumerSaslPassword";

        public const string AdminClientBootstrapServers = "KafkaAdminClientBootstrapServers";
        public const string AdminClientSaslUsername = "KafkaAdminClientSaslUsername";
        public const string AdminClientPassword = "KafkaAdminClientPassword";

        public const string GroupId = "KafkaOptions:GroupId";
        public const string ClientId = "KafkaOptions:ClientId";
        public const string ProjectName = "KafkaOptions:ProjectName";
        public const string ServiceName = "KafkaOptions:ServiceName";
    }
}
