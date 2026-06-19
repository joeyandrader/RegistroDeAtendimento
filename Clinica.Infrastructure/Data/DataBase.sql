-- 1. criar tb de user primeiro porque o address depende dela.
CREATE TABLE Users (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    DateOfBirth TIMESTAMP NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    Sex INT NOT NULL,
    Status INT NOT NULL,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP NULL
);

-- 2. depois criar o address
CREATE TABLE UserAddresses (
    Id SERIAL PRIMARY KEY,
    AddressLine1 VARCHAR(255) NULL,
    AddressLine2 VARCHAR(255) NULL,
    Neighborhood VARCHAR(100) NULL,
    City VARCHAR(100) NULL,
    State VARCHAR(50) NULL,
    Country VARCHAR(50) NULL,
    ZipCode VARCHAR(20) NULL,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP NULL,
    UserId INT NOT NULL,
    CONSTRAINT FK_UserAddresses_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT UQ_UserAddresses_UserId UNIQUE (UserId)
);

CREATE TABLE appointments (
    Id SERIAL PRIMARY KEY,
    UserId INT NOT NULL,
    AppointmentDate TIMESTAMP NOT NULL,
    Status INT NOT NULL,
    Description VARCHAR(255) NOT NULL,

    CONSTRAINT fk_user
    FOREIGN KEY (UserId) REFERENCES users(id)
);