/* 3. Çalýþmanýn Çözümü */

------------------------------------------------------------------------------------------------
-- Tablolar þemadaki gibi oluþturulur

CREATE TABLE test_groups(
    name VARCHAR(40) NOT NULL, 
    test_value INTEGER NOT NULL, 
    UNIQUE(name)
);
  
CREATE TABLE test_cases(
    id INTEGER NOT NULL, 
    group_name VARCHAR(40) NOT NULL, 
    status VARCHAR(5) NOT NULL, 
    UNIQUE(id)
);

------------------------------------------------------------------------------------------------
-- Ýlgili tablolara veriler eklenir

INSERT INTO test_groups (name, test_value) VALUES
('performance', 15),
('corner cases', 10), 
('numerical stability', 20), 
('memory usage', 10);
  
INSERT INTO test_cases (id, group_name, status) VALUES 
(13, 'memory usage', 'OK'),
(14, 'numerical stability', 'OK'),
(15, 'memory usage', 'ERROR'),
(16, 'numerical stability', 'OK'),
(17, 'numerical stability', 'OK'),
(18, 'performance', 'ERROR'),
(19, 'performance', 'ERROR'),
(20, 'memory usage', 'OK'),
(21, 'numerical stability', 'OK');

------------------------------------------------------------------------------------------------
-- Ýstenilen SQL sorgusunun son hali

SELECT T.name,
       COUNT(C) AS all_test_cases,
       SUM(CASE WHEN C.status = 'OK' THEN 1 ELSE 0 END) AS passed_test_cases,
	   CASE WHEN SUM(CASE WHEN C.status = 'OK' THEN test_value END) IS NULL THEN 0
       ELSE SUM(CASE WHEN C.status = 'OK' THEN test_value END) END AS total_value
FROM test_groups T
LEFT JOIN test_cases C ON T.name = C.group_name
GROUP BY T.name
ORDER BY total_value DESC, T.name;