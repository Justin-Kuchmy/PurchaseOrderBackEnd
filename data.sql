INSERT INTO dbo.Vendors (Address1,City,Province,PostalCode,Phone,Type,Name,Email)VALUES ('123 Maple 
St','London','On', 'N1N-1N1','(555)555-5555','Trusted','ABC Supply Co.','abc@supply.com');
INSERT INTO dbo.Vendors (Address1,City,Province,PostalCode,Phone,Type,Name,Email) VALUES ('543 
Sycamore Ave','Toronto','On', 'N1P-1N1','(999)555-5555','Trusted','Big Bills 
Depot','bb@depot.com');
INSERT INTO dbo.Vendors (Address1,City,Province,PostalCode,Phone,Type,Name,Email) VALUES ('922 Oak 
St','London','On', 'N1N-1N1','(555)555-5599','Untrusted','Shady Sams','ss@underthetable.com');
INSERT INTO dbo.Vendors (Address1,City,Province,PostalCode,Phone,Type,Name,Email) VALUES ('132 fanshawe
St','London','On', 'N1N-1N1','(555)555-5599','Untrusted','Justin Kuchmy','JK@isastrongguy.com');


INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('12X45', 1, 'cool thing',     19.99, 159.99, 10,  5, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('14X46', 1, 'cool object',     20.99, 359.99,  10, 10, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('16X47', 2, 'cool sphere',     21.99, 119.99, 10,  4, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('18X48', 2, 'cool computer',   22.99, 119.99, 10,  7, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('20X45', 3, 'cool mug',        23.99, 119.99, 10,  3, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('22X46', 3, 'cool phone',      24.99, 119.99, 10,  8, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('24X47', 4, 'cool toy',        25.99, 119.99, 10,  9, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('26X48', 4, 'cool var',        26.99, 119.99,  10, 12, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('30X48', 4, 'cool game',        30.99, 119.99,  10, 15, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('12X450', 1, 'Another Cool thing',     19.99, 159.99, 10,  5, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('14X460', 1, 'Another Cool object',     20.99, 359.99,  10, 10, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('16X470', 2, 'Another Cool sphere',     21.99, 119.99, 10,  4, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('18X480', 2, 'Another Cool computer',   22.99, 119.99, 10,  7, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('20X450', 3, 'Another Cool mug',        23.99, 119.99, 10,  3, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('22X460', 3, 'Another Cool phone',      24.99, 119.99, 10,  8, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('24X470', 4, 'Another Cool toy',        25.99, 119.99, 10,  9, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('26X480', 4, 'Another Cool var',        26.99, 119.99,  10, 12, 22, 0);
INSERT INTO dbo.Products (id,vendorid,name,costprice,msrp,rop,eoq,qoh,qoo) VALUES ('30X480', 4, 'Another Cool game',        30.99, 119.99,  10, 15, 22, 0);
