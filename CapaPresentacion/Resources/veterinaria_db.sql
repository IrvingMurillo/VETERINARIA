-- Eliminar la base de datos si ya existe para evitar duplicados
DROP DATABASE IF EXISTS veterinaria_db;

-- Crear una nueva base de datos
CREATE DATABASE veterinaria_db;

-- Usar la base de datos recién creada
USE veterinaria_db;

-- ===========================
-- 1. Crear la tabla ROL
-- ===========================
CREATE TABLE ROL (
    IdRol INT PRIMARY KEY AUTO_INCREMENT,
    Descripcion VARCHAR(100),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ===========================
-- 2. Crear la tabla PERMISO (dependiente de ROL)
-- ===========================
CREATE TABLE PERMISO (
    IdPermiso INT PRIMARY KEY AUTO_INCREMENT,
    IdRol INT, -- Relación con la tabla ROL
    NombreMenu VARCHAR(100),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdRol) REFERENCES ROL(IdRol) -- Relación con la tabla ROL
);

-- ===========================
-- 3. Crear la tabla USUARIO (dependiente de ROL)
-- ===========================
CREATE TABLE USUARIO (
    IdUsuario INT PRIMARY KEY AUTO_INCREMENT,
    Documento VARCHAR(50),
    NombreCompleto VARCHAR(100),
    Correo VARCHAR(100),
    Clave VARCHAR(255),
    IdRol INT, -- Relación con la tabla ROL
    Estado BIT, -- TINYINT(1),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdRol) REFERENCES ROL(IdRol) -- Relación con la tabla ROL
);

-- ===========================
-- 4. Crear la tabla CATEGORIA
-- ===========================
CREATE TABLE CATEGORIA (
    IdCategoria INT PRIMARY KEY AUTO_INCREMENT,
    Descripcion VARCHAR(100),
    Estado BIT, -- TINYINT(1),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ===========================
-- 5. Crear la tabla PRODUCTO (dependiente de CATEGORIA)
-- ===========================
CREATE TABLE PRODUCTO (
    IdProducto INT PRIMARY KEY AUTO_INCREMENT,
    Codigo VARCHAR(50),
    Nombre VARCHAR(100),
    Descripcion TEXT,
    IdCategoria INT, -- Relación con la tabla CATEGORIA
    Stock INT NOT NULL DEFAULT 0,
    PrecioCompra DECIMAL(10, 2) DEFAULT 0,
    PrecioVenta DECIMAL(10, 2) DEFAULT 0,
    Estado BIT, -- TINYINT(1),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdCategoria) REFERENCES CATEGORIA(IdCategoria) -- Relación con la tabla CATEGORIA
);

-- ===========================
-- 6. Crear la tabla PROVEEDOR
-- ===========================
CREATE TABLE PROVEEDOR (
    IdProveedor INT PRIMARY KEY AUTO_INCREMENT,
    Documento VARCHAR(50),
    RazonSocial VARCHAR(100),
    Correo VARCHAR(100),
    Telefono VARCHAR(20),
    Estado BIT, -- TINYINT(1),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ===========================
-- 7. Crear la tabla CLIENTE
-- ===========================
CREATE TABLE CLIENTE (
    IdCliente INT PRIMARY KEY AUTO_INCREMENT,
    Documento VARCHAR(50),
    NombreCompleto VARCHAR(100),
    Correo VARCHAR(100),
    Telefono VARCHAR(20),
    Estado BIT, -- TINYINT(1),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ===========================
-- 8. Crear la tabla COMPRA (dependiente de USUARIO y PROVEEDOR)
-- ===========================
CREATE TABLE COMPRA (
    IdCompra INT PRIMARY KEY AUTO_INCREMENT,
    IdUsuario INT, -- Relación con la tabla USUARIO
    IdProveedor INT, -- Relación con la tabla PROVEEDOR
    TipoDocumento VARCHAR(50),
    NumeroDocumento VARCHAR(50),
    MontoTotal DECIMAL(10, 2),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdUsuario) REFERENCES USUARIO(IdUsuario), -- Relación con la tabla USUARIO
    FOREIGN KEY (IdProveedor) REFERENCES PROVEEDOR(IdProveedor) -- Relación con la tabla PROVEEDOR
);

-- ===========================
-- 9. Crear la tabla VENTA (dependiente de USUARIO y CLIENTE)
-- ===========================
CREATE TABLE VENTA (
    IdVenta INT PRIMARY KEY AUTO_INCREMENT,
    IdUsuario INT, -- Relación con la tabla USUARIO
    TipoDocumento VARCHAR(50),
    NumeroDocumento VARCHAR(50),
    DocumentoCliente VARCHAR(50),
    NombreCliente VARCHAR(100),
    MontoPago DECIMAL(10, 2),
    MontoCambio DECIMAL(10, 2),
    MontoTotal DECIMAL(10, 2),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdUsuario) REFERENCES USUARIO(IdUsuario) -- Relación con la tabla USUARIO
);

-- ===========================
-- 10. Crear la tabla DETALLE_COMPRA (dependiente de COMPRA y PRODUCTO)
-- ===========================
CREATE TABLE DETALLE_COMPRA (
    IdDetalleCompra INT PRIMARY KEY AUTO_INCREMENT,
    IdCompra INT, -- Relación con la tabla COMPRA
    IdProducto INT, -- Relación con la tabla PRODUCTO
    PrecioCompra DECIMAL(10, 2) DEFAULT 0,
    PrecioVenta DECIMAL(10, 2) DEFAULT 0,
    Cantidad INT,
    MontoTotal DECIMAL(10, 2),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdCompra) REFERENCES COMPRA(IdCompra), -- Relación con la tabla COMPRA
    FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto) -- Relación con la tabla PRODUCTO
);

-- ===========================
-- 11. Crear la tabla DETALLE_VENTA (dependiente de VENTA y PRODUCTO)
-- ===========================
CREATE TABLE DETALLE_VENTA (
    IdDetalleVenta INT PRIMARY KEY AUTO_INCREMENT,
    IdVenta INT, -- Relación con la tabla VENTA
    IdProducto INT, -- Relación con la tabla PRODUCTO
    PrecioVenta DECIMAL(10, 2),
    Cantidad INT,
    SubTotal DECIMAL(10, 2),
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (IdVenta) REFERENCES VENTA(IdVenta), -- Relación con la tabla VENTA
    FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(IdProducto) -- Relación con la tabla PRODUCTO
);






-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo rol
CREATE PROCEDURE SP_RegistrarRol(
    IN p_Descripcion VARCHAR(100),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el rol';
    END;

    -- Insertar nuevo rol
    INSERT INTO ROL (Descripcion) VALUES (p_Descripcion);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Rol registrado exitosamente';
END //

-- Procedimiento para editar un rol existente
CREATE PROCEDURE sp_EditarRol(
    IN p_IdRol INT,
    IN p_Descripcion VARCHAR(100),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el rol';
    END;

    -- Actualizar rol existente
    UPDATE ROL SET Descripcion = p_Descripcion WHERE IdRol = p_IdRol;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Rol editado exitosamente';
END //

-- Procedimiento para eliminar un rol existente
CREATE PROCEDURE sp_EliminarRol(
    IN p_IdRol INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el rol';
    END;

    -- Eliminar rol existente
    DELETE FROM ROL WHERE IdRol = p_IdRol;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Rol eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo permiso
CREATE PROCEDURE SP_RegistrarPermiso(
    IN p_IdRol INT,
    IN p_NombreMenu VARCHAR(100),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el permiso';
    END;

    -- Insertar nuevo permiso
    INSERT INTO PERMISO (IdRol, NombreMenu) VALUES (p_IdRol, p_NombreMenu);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Permiso registrado exitosamente';
END //

-- Procedimiento para editar un permiso existente
CREATE PROCEDURE sp_EditarPermiso(
    IN p_IdPermiso INT,
    IN p_IdRol INT,
    IN p_NombreMenu VARCHAR(100),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el permiso';
    END;

    -- Actualizar permiso existente
    UPDATE PERMISO SET IdRol = p_IdRol, NombreMenu = p_NombreMenu WHERE IdPermiso = p_IdPermiso;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Permiso editado exitosamente';
END //

-- Procedimiento para eliminar un permiso existente
CREATE PROCEDURE sp_EliminarPermiso(
    IN p_IdPermiso INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el permiso';
    END;

    -- Eliminar permiso existente
    DELETE FROM PERMISO WHERE IdPermiso = p_IdPermiso;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Permiso eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo usuario
CREATE PROCEDURE SP_RegistrarUsuario(
    IN p_Documento VARCHAR(50),
    IN p_NombreCompleto VARCHAR(100),
    IN p_Correo VARCHAR(100),
    IN p_Clave VARCHAR(255),
    IN p_IdRol INT,
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el usuario';
    END;

    -- Insertar nuevo usuario
    INSERT INTO USUARIO (Documento, NombreCompleto, Correo, Clave, IdRol, Estado) 
    VALUES (p_Documento, p_NombreCompleto, p_Correo, p_Clave, p_IdRol, p_Estado);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Usuario registrado exitosamente';
END //

-- Procedimiento para editar un usuario existente
CREATE PROCEDURE sp_EditarUsuario(
    IN p_IdUsuario INT,
    IN p_Documento VARCHAR(50),
    IN p_NombreCompleto VARCHAR(100),
    IN p_Correo VARCHAR(100),
    IN p_Clave VARCHAR(255),
    IN p_IdRol INT,
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el usuario';
    END;

    -- Actualizar usuario existente
    UPDATE USUARIO 
    SET Documento = p_Documento, 
        NombreCompleto = p_NombreCompleto, 
        Correo = p_Correo, 
        Clave = p_Clave, 
        IdRol = p_IdRol, 
        Estado = p_Estado 
    WHERE IdUsuario = p_IdUsuario;
    
    SET p_Resultado = 1;
    SET p_Mensaje = 'Usuario editado exitosamente';
END //

-- Procedimiento para eliminar un usuario existente
CREATE PROCEDURE sp_EliminarUsuario(
    IN p_IdUsuario INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el usuario';
    END;

    -- Eliminar usuario existente
    DELETE FROM USUARIO WHERE IdUsuario = p_IdUsuario;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Usuario eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar una nueva categoría
CREATE PROCEDURE SP_RegistrarCategoria(
    IN p_Descripcion VARCHAR(100),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar la categoría';
    END;

    -- Insertar nueva categoría
    INSERT INTO CATEGORIA (Descripcion, Estado) VALUES (p_Descripcion, p_Estado);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Categoría registrada exitosamente';
END //

-- Procedimiento para editar una categoría existente
CREATE PROCEDURE sp_EditarCategoria(
    IN p_IdCategoria INT,
    IN p_Descripcion VARCHAR(100),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar la categoría';
    END;

    -- Actualizar categoría existente
    UPDATE CATEGORIA SET Descripcion = p_Descripcion, Estado = p_Estado WHERE IdCategoria = p_IdCategoria;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Categoría editada exitosamente';
END //

-- Procedimiento para eliminar una categoría existente
CREATE PROCEDURE sp_EliminarCategoria(
    IN p_IdCategoria INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar la categoría';
    END;

    -- Eliminar categoría existente
    DELETE FROM CATEGORIA WHERE IdCategoria = p_IdCategoria;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Categoría eliminada exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo producto
CREATE PROCEDURE SP_RegistrarProducto(
    IN p_Codigo VARCHAR(50),
    IN p_Nombre VARCHAR(100),
    IN p_Descripcion TEXT,
    IN p_IdCategoria INT,
    IN p_Stock INT,
    IN p_PrecioCompra DECIMAL(10, 2),
    IN p_PrecioVenta DECIMAL(10, 2),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el producto';
    END;

    -- Insertar nuevo producto
    INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, IdCategoria, Stock, PrecioCompra, PrecioVenta, Estado) 
    VALUES (p_Codigo, p_Nombre, p_Descripcion, p_IdCategoria, p_Stock, p_PrecioCompra, p_PrecioVenta, p_Estado);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Producto registrado exitosamente';
END //

-- Procedimiento para editar un producto existente
CREATE PROCEDURE sp_EditarProducto(
    IN p_IdProducto INT,
    IN p_Codigo VARCHAR(50),
    IN p_Nombre VARCHAR(100),
    IN p_Descripcion TEXT,
    IN p_IdCategoria INT,
    IN p_Stock INT,
    IN p_PrecioCompra DECIMAL(10, 2),
    IN p_PrecioVenta DECIMAL(10, 2),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el producto';
    END;

    -- Actualizar producto existente
    UPDATE PRODUCTO 
    SET Codigo = p_Codigo, Nombre = p_Nombre, Descripcion = p_Descripcion, IdCategoria = p_IdCategoria, 
        Stock = p_Stock, PrecioCompra = p_PrecioCompra, PrecioVenta = p_PrecioVenta, Estado = p_Estado 
    WHERE IdProducto = p_IdProducto;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Producto editado exitosamente';
END //

-- Procedimiento para eliminar un producto existente
CREATE PROCEDURE sp_EliminarProducto(
    IN p_IdProducto INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el producto';
    END;

    -- Eliminar producto existente
    DELETE FROM PRODUCTO WHERE IdProducto = p_IdProducto;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Producto eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo proveedor
CREATE PROCEDURE SP_RegistrarProveedor(
    IN p_Documento VARCHAR(50),
    IN p_RazonSocial VARCHAR(100),
    IN p_Correo VARCHAR(100),
    IN p_Telefono VARCHAR(20),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el proveedor';
    END;

    -- Insertar nuevo proveedor
    INSERT INTO PROVEEDOR (Documento, RazonSocial, Correo, Telefono, Estado) 
    VALUES (p_Documento, p_RazonSocial, p_Correo, p_Telefono, p_Estado);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Proveedor registrado exitosamente';
END //

-- Procedimiento para editar un proveedor existente
CREATE PROCEDURE sp_EditarProveedor(
    IN p_IdProveedor INT,
    IN p_Documento VARCHAR(50),
    IN p_RazonSocial VARCHAR(100),
    IN p_Correo VARCHAR(100),
    IN p_Telefono VARCHAR(20),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el proveedor';
    END;

    -- Actualizar proveedor existente
    UPDATE PROVEEDOR 
    SET Documento = p_Documento, RazonSocial = p_RazonSocial, Correo = p_Correo, Telefono = p_Telefono, Estado = p_Estado 
    WHERE IdProveedor = p_IdProveedor;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Proveedor editado exitosamente';
END //

-- Procedimiento para eliminar un proveedor existente
CREATE PROCEDURE sp_EliminarProveedor(
    IN p_IdProveedor INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el proveedor';
    END;

    -- Eliminar proveedor existente
    DELETE FROM PROVEEDOR WHERE IdProveedor = p_IdProveedor;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Proveedor eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo cliente
CREATE PROCEDURE SP_RegistrarCliente(
    IN p_Documento VARCHAR(50),
    IN p_NombreCompleto VARCHAR(100),
    IN p_Correo VARCHAR(100),
    IN p_Telefono VARCHAR(20),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el cliente';
    END;

    -- Insertar nuevo cliente
    INSERT INTO CLIENTE (Documento, NombreCompleto, Correo, Telefono, Estado) 
    VALUES (p_Documento, p_NombreCompleto, p_Correo, p_Telefono, p_Estado);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Cliente registrado exitosamente';
END //

-- Procedimiento para editar un cliente existente
CREATE PROCEDURE sp_EditarCliente(
    IN p_IdCliente INT,
    IN p_Documento VARCHAR(50),
    IN p_NombreCompleto VARCHAR(100),
    IN p_Correo VARCHAR(100),
    IN p_Telefono VARCHAR(20),
    IN p_Estado BIT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el cliente';
    END;

    -- Actualizar cliente existente
    UPDATE CLIENTE 
    SET Documento = p_Documento, NombreCompleto = p_NombreCompleto, Correo = p_Correo, Telefono = p_Telefono, Estado = p_Estado 
    WHERE IdCliente = p_IdCliente;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Cliente editado exitosamente';
END //

-- Procedimiento para eliminar un cliente existente
CREATE PROCEDURE sp_EliminarCliente(
    IN p_IdCliente INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el cliente';
    END;

    -- Eliminar cliente existente
    DELETE FROM CLIENTE WHERE IdCliente = p_IdCliente;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Cliente eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar una nueva compra
CREATE PROCEDURE SP_RegistrarCompra(
    IN p_IdUsuario INT,
    IN p_IdProveedor INT,
    IN p_TipoDocumento VARCHAR(50),
    IN p_NumeroDocumento VARCHAR(50),
    IN p_MontoTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar la compra';
    END;

    -- Insertar nueva compra
    INSERT INTO COMPRA (IdUsuario, IdProveedor, TipoDocumento, NumeroDocumento, MontoTotal) 
    VALUES (p_IdUsuario, p_IdProveedor, p_TipoDocumento, p_NumeroDocumento, p_MontoTotal);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Compra registrada exitosamente';
END //

-- Procedimiento para editar una compra existente
CREATE PROCEDURE sp_EditarCompra(
    IN p_IdCompra INT,
    IN p_IdUsuario INT,
    IN p_IdProveedor INT,
    IN p_TipoDocumento VARCHAR(50),
    IN p_NumeroDocumento VARCHAR(50),
    IN p_MontoTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar la compra';
    END;

    -- Actualizar compra existente
    UPDATE COMPRA 
    SET IdUsuario = p_IdUsuario, IdProveedor = p_IdProveedor, TipoDocumento = p_TipoDocumento, 
        NumeroDocumento = p_NumeroDocumento, MontoTotal = p_MontoTotal 
    WHERE IdCompra = p_IdCompra;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Compra editada exitosamente';
END //

-- Procedimiento para eliminar una compra existente
CREATE PROCEDURE sp_EliminarCompra(
    IN p_IdCompra INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar la compra';
    END;

    -- Eliminar compra existente
    DELETE FROM COMPRA WHERE IdCompra = p_IdCompra;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Compra eliminada exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar una nueva venta
CREATE PROCEDURE SP_RegistrarVenta(
    IN p_IdUsuario INT,
    IN p_TipoDocumento VARCHAR(50),
    IN p_NumeroDocumento VARCHAR(50),
    IN p_DocumentoCliente VARCHAR(50),
    IN p_NombreCliente VARCHAR(100),
    IN p_MontoPago DECIMAL(10, 2),
    IN p_MontoCambio DECIMAL(10, 2),
    IN p_MontoTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar la venta';
    END;

    -- Insertar nueva venta
    INSERT INTO VENTA (IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal) 
    VALUES (p_IdUsuario, p_TipoDocumento, p_NumeroDocumento, p_DocumentoCliente, p_NombreCliente, p_MontoPago, p_MontoCambio, p_MontoTotal);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Venta registrada exitosamente';
END //

-- Procedimiento para editar una venta existente
CREATE PROCEDURE sp_EditarVenta(
    IN p_IdVenta INT,
    IN p_IdUsuario INT,
    IN p_TipoDocumento VARCHAR(50),
    IN p_NumeroDocumento VARCHAR(50),
    IN p_DocumentoCliente VARCHAR(50),
    IN p_NombreCliente VARCHAR(100),
    IN p_MontoPago DECIMAL(10, 2),
    IN p_MontoCambio DECIMAL(10, 2),
    IN p_MontoTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar la venta';
    END;

    -- Actualizar venta existente
    UPDATE VENTA 
    SET IdUsuario = p_IdUsuario, TipoDocumento = p_TipoDocumento, NumeroDocumento = p_NumeroDocumento, 
        DocumentoCliente = p_DocumentoCliente, NombreCliente = p_NombreCliente, MontoPago = p_MontoPago, 
        MontoCambio = p_MontoCambio, MontoTotal = p_MontoTotal 
    WHERE IdVenta = p_IdVenta;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Venta editada exitosamente';
END //

-- Procedimiento para eliminar una venta existente
CREATE PROCEDURE sp_EliminarVenta(
    IN p_IdVenta INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar la venta';
    END;

    -- Eliminar venta existente
    DELETE FROM VENTA WHERE IdVenta = p_IdVenta;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Venta eliminada exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo detalle de compra
CREATE PROCEDURE SP_RegistrarDetalleCompra(
    IN p_IdCompra INT,
    IN p_IdProducto INT,
    IN p_PrecioCompra DECIMAL(10, 2),
    IN p_PrecioVenta DECIMAL(10, 2),
    IN p_Cantidad INT,
    IN p_MontoTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el detalle de compra';
    END;

    -- Insertar nuevo detalle de compra
    INSERT INTO DETALLE_COMPRA (IdCompra, IdProducto, PrecioCompra, PrecioVenta, Cantidad, MontoTotal) 
    VALUES (p_IdCompra, p_IdProducto, p_PrecioCompra, p_PrecioVenta, p_Cantidad, p_MontoTotal);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Detalle de compra registrado exitosamente';
END //

-- Procedimiento para editar un detalle de compra existente
CREATE PROCEDURE sp_EditarDetalleCompra(
    IN p_IdDetalleCompra INT,
    IN p_IdCompra INT,
    IN p_IdProducto INT,
    IN p_PrecioCompra DECIMAL(10, 2),
    IN p_PrecioVenta DECIMAL(10, 2),
    IN p_Cantidad INT,
    IN p_MontoTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el detalle de compra';
    END;

    -- Actualizar detalle de compra existente
    UPDATE DETALLE_COMPRA 
    SET IdCompra = p_IdCompra, IdProducto = p_IdProducto, PrecioCompra = p_PrecioCompra, 
        PrecioVenta = p_PrecioVenta, Cantidad = p_Cantidad, MontoTotal = p_MontoTotal 
    WHERE IdDetalleCompra = p_IdDetalleCompra;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Detalle de compra editado exitosamente';
END //

-- Procedimiento para eliminar un detalle de compra existente
CREATE PROCEDURE sp_EliminarDetalleCompra(
    IN p_IdDetalleCompra INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el detalle de compra';
    END;

    -- Eliminar detalle de compra existente
    DELETE FROM DETALLE_COMPRA WHERE IdDetalleCompra = p_IdDetalleCompra;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Detalle de compra eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Crear Procedimientos Almacenados
-- ===========================

DELIMITER //

-- Procedimiento para registrar un nuevo detalle de venta
CREATE PROCEDURE SP_RegistrarDetalleVenta(
    IN p_IdVenta INT,
    IN p_IdProducto INT,
    IN p_PrecioVenta DECIMAL(10, 2),
    IN p_Cantidad INT,
    IN p_SubTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al registrar el detalle de venta';
    END;

    -- Insertar nuevo detalle de venta
    INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, PrecioVenta, Cantidad, SubTotal) 
    VALUES (p_IdVenta, p_IdProducto, p_PrecioVenta, p_Cantidad, p_SubTotal);
    SET p_Resultado = LAST_INSERT_ID();
    SET p_Mensaje = 'Detalle de venta registrado exitosamente';
END //

-- Procedimiento para editar un detalle de venta existente
CREATE PROCEDURE sp_EditarDetalleVenta(
    IN p_IdDetalleVenta INT,
    IN p_IdVenta INT,
    IN p_IdProducto INT,
    IN p_PrecioVenta DECIMAL(10, 2),
    IN p_Cantidad INT,
    IN p_SubTotal DECIMAL(10, 2),
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al editar el detalle de venta';
    END;

    -- Actualizar detalle de venta existente
    UPDATE DETALLE_VENTA 
    SET IdVenta = p_IdVenta, IdProducto = p_IdProducto, PrecioVenta = p_PrecioVenta, 
        Cantidad = p_Cantidad, SubTotal = p_SubTotal 
    WHERE IdDetalleVenta = p_IdDetalleVenta;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Detalle de venta editado exitosamente';
END //

-- Procedimiento para eliminar un detalle de venta existente
CREATE PROCEDURE sp_EliminarDetalleVenta(
    IN p_IdDetalleVenta INT,
    OUT p_Resultado INT,
    OUT p_Mensaje VARCHAR(500)
)
BEGIN
    -- Manejar excepciones SQL
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SET p_Resultado = 0;
        SET p_Mensaje = 'Error al eliminar el detalle de venta';
    END;

    -- Eliminar detalle de venta existente
    DELETE FROM DETALLE_VENTA WHERE IdDetalleVenta = p_IdDetalleVenta;
    SET p_Resultado = 1;
    SET p_Mensaje = 'Detalle de venta eliminado exitosamente';
END //

DELIMITER ;




-- ===========================
-- Conceder Permisos
-- ===========================

-- Permisos para la tabla ROL
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarRol TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarRol TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarRol TO 'root'@'localhost';

-- Permisos para la tabla PERMISO
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarPermiso TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarPermiso TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarPermiso TO 'root'@'localhost';

-- Permisos para la tabla USUARIO
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarUsuario TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarUsuario TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarUsuario TO 'root'@'localhost';

-- Permisos para la tabla CATEGORIA
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarCategoria TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarCategoria TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarCategoria TO 'root'@'localhost';

-- Permisos para la tabla PRODUCTO
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarProducto TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarProducto TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarProducto TO 'root'@'localhost';

-- Permisos para la tabla PROVEEDOR
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarProveedor TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarProveedor TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarProveedor TO 'root'@'localhost';

-- Permisos para la tabla CLIENTE
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarCliente TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarCliente TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarCliente TO 'root'@'localhost';

-- Permisos para la tabla COMPRA
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarCompra TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarCompra TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarCompra TO 'root'@'localhost';

-- Permisos para la tabla VENTA
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarVenta TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarVenta TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarVenta TO 'root'@'localhost';

-- Permisos para la tabla DETALLE_COMPRA
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarDetalleCompra TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarDetalleCompra TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarDetalleCompra TO 'root'@'localhost';

-- Permisos para la tabla DETALLE_VENTA
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_RegistrarDetalleVenta TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EditarDetalleVenta TO 'root'@'localhost';
GRANT EXECUTE ON PROCEDURE veterinaria_db.SP_EliminarDetalleVenta TO 'root'@'localhost';

-- Aplicar los cambios
FLUSH PRIVILEGES;

-- Usar la base de datos veterinaria_db
USE veterinaria_db;

-- Insertar roles en la tabla ROL
CALL SP_RegistrarRol('ADMINISTRADOR', @Resultado, @Mensaje);
CALL SP_RegistrarRol('EMPLEADO', @Resultado, @Mensaje);

-- Insertar permisos para ADMINISTRADORES (IdRol=1)
CALL SP_RegistrarPermiso(1, 'USUARIOS', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'MANTENEDOR', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'VENTAS', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'COMPRAS', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'CLIENTES', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'PROVEEDORES', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'REPORTES', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(1, 'ACERCA_DE', @Resultado, @Mensaje);

-- Insertar permisos para EMPLEADOS (IdRol=2)
CALL SP_RegistrarPermiso(2, 'VENTAS', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(2, 'COMPRAS', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(2, 'CLIENTES', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(2, 'PROVEEDORES', @Resultado, @Mensaje);
CALL SP_RegistrarPermiso(2, 'ACERCA_DE', @Resultado, @Mensaje);

-- Insertar usuarios ADMINISTRADORES (IdRol=1)
CALL SP_RegistrarUsuario('101010', 'ADMIN 1', 'admin1@gmail.com', 'admin123', 1, 1, @Resultado, @Mensaje);
CALL SP_RegistrarUsuario('202020', 'ADMIN 2', 'admin2@gmail.com', 'admin123', 1, 1, @Resultado, @Mensaje);
CALL SP_RegistrarUsuario('303030', 'ADMIN 3', 'admin3@gmail.com', 'admin123', 1, 1, @Resultado, @Mensaje);

-- Insertar usuarios EMPLEADOS (IdRol=2)
CALL SP_RegistrarUsuario('404040', 'EMPLEADO 1', 'empleado1@gmail.com', 'empleado123', 2, 1, @Resultado, @Mensaje);
CALL SP_RegistrarUsuario('505050', 'EMPLEADO 2', 'empleado2@gmail.com', 'empleado123', 2, 1, @Resultado, @Mensaje);
CALL SP_RegistrarUsuario('606060', 'EMPLEADO 3', 'empleado3@gmail.com', 'empleado123', 2, 1, @Resultado, @Mensaje);

-- Insertar categorías en la tabla CATEGORIA
CALL SP_RegistrarCategoria('Medicamentos', 1, @Resultado, @Mensaje);
CALL SP_RegistrarCategoria('Alimentos', 1, @Resultado, @Mensaje);
CALL SP_RegistrarCategoria('Accesorios', 1, @Resultado, @Mensaje);
CALL SP_RegistrarCategoria('Juguetes', 1, @Resultado, @Mensaje);

-- Insertar productos en la tabla PRODUCTO
CALL SP_RegistrarProducto('MED001', 'Antiparasitario', 'Antiparasitario para perros', 1, 100, 5.00, 10.00, 1, @Resultado, @Mensaje);
CALL SP_RegistrarProducto('ALM001', 'Alimento para perros', 'Alimento balanceado para perros adultos', 2, 200, 20.00, 40.00, 1, @Resultado, @Mensaje);
CALL SP_RegistrarProducto('ACC001', 'Collar', 'Collar ajustable para perros', 3, 150, 2.00, 5.00, 1, @Resultado, @Mensaje);
CALL SP_RegistrarProducto('JU001', 'Pelota', 'Pelota de goma para perros', 4, 300, 1.00, 3.00, 1, @Resultado, @Mensaje);

-- Insertar proveedores en la tabla PROVEEDOR
CALL SP_RegistrarProveedor('12345678', 'Proveedor 1', 'proveedor1@gmail.com', '123456789', 1, @Resultado, @Mensaje);
CALL SP_RegistrarProveedor('87654321', 'Proveedor 2', 'proveedor2@gmail.com', '987654321', 1, @Resultado, @Mensaje);

-- Insertar clientes en la tabla CLIENTE
CALL SP_RegistrarCliente('11111111', 'Cliente 1', 'cliente1@gmail.com', '111111111', 1, @Resultado, @Mensaje);
CALL SP_RegistrarCliente('22222222', 'Cliente 2', 'cliente2@gmail.com', '222222222', 1, @Resultado, @Mensaje);

-- Insertar compras en la tabla COMPRA
CALL SP_RegistrarCompra(1, 1, 'Factura', 'F001', 500.00, @Resultado, @Mensaje);
CALL SP_RegistrarCompra(2, 2, 'Boleta', 'B001', 300.00, @Resultado, @Mensaje);

-- Insertar ventas en la tabla VENTA
CALL SP_RegistrarVenta(1, 'Factura', 'F001', '11111111', 'Cliente 1', 100.00, 0.00, 100.00, @Resultado, @Mensaje);
CALL SP_RegistrarVenta(2, 'Boleta', 'B001', '22222222', 'Cliente 2', 150.00, 0.00, 150.00, @Resultado, @Mensaje);

-- Insertar detalles de compra en la tabla DETALLE_COMPRA
CALL SP_RegistrarDetalleCompra(1, 1, 5.00, 10.00, 50, 250.00, @Resultado, @Mensaje);
CALL SP_RegistrarDetalleCompra(1, 2, 20.00, 40.00, 10, 200.00, @Resultado, @Mensaje);
CALL SP_RegistrarDetalleCompra(2, 3, 2.00, 5.00, 25, 50.00, @Resultado, @Mensaje);

-- Insertar detalles de venta en la tabla DETALLE_VENTA
CALL SP_RegistrarDetalleVenta(1, 1, 10.00, 5, 50.00, @Resultado, @Mensaje);
CALL SP_RegistrarDetalleVenta(1, 2, 40.00, 1, 40.00, @Resultado, @Mensaje);
CALL SP_RegistrarDetalleVenta(2, 3, 5.00, 10, 50.00, @Resultado, @Mensaje);

