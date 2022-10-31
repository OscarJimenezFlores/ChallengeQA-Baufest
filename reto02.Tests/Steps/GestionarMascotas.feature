Feature: Gestionar Mascotas

Scenario: Agregar mascota correctamente
    Given Teniendo el nombre Guauguau02 y categoria Perro
    When Envia peticion de agregar
    Then Retorna mensaje satisfactorio

Scenario: Obtener mascota
    Given El identificador de la mascota 1000
    When Envia peticion de Obtener
    Then Retorna una mascota de nombre Guauguau02

Scenario: Actualizar mascota correctamente
    Given Busco identificador de la mascota 1000 y actualizo el nombre por Belvedere
    When Envia peticion de Actualizar
    Then Retorna mensaje satisfactorio