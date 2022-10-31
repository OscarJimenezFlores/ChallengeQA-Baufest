Feature: Dar de alta un usuario

Scenario: Dar de alta un usuario con resultado exitoso
    Given Ir a la pagina https://www.demoblaze.com/index.html
    And Presionar link Sign Up
    And Introducir el nombre usuario guauguau101 y password guauguau2
    When Presione click en el boton Sign Up
    Then Mensaje de usuario dado de alta satisfactoriamente


Scenario: Dar de alta un usuario con resultado erroneo
    Given Ir a la pagina https://www.demoblaze.com/index.html
    And Presionar link Sign Up
    And Introducir el nombre usuario guauguau6 y password guauguau2
    When Presione click en el boton Sign Up
    Then Mensaje de usuario ya existente
