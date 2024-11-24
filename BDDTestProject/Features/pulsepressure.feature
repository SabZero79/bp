@FeatureTest
Feature: Pulse Pressure
Feature: Pulse Pressure Calculation
    In order to calculate pulse pressure correctly
    As a healthcare professional
    I want to see the pulse pressure based on systolic and diastolic values

    Scenario: 10
        Given the systolic pressure is 85
        And the diastolic pressure is 75
        When I calculate the pulse pressure
        Then the value should be 10

    Scenario: 30
        Given the systolic pressure is 115
        And the diastolic pressure is 85
        When I calculate the pulse pressure
        Then the value should be 30

    Scenario: 40
        Given the systolic pressure is 125
        And the diastolic pressure is 85
        When I calculate the pulse pressure
        Then the value should be 40

    Scenario: 50
        Given the systolic pressure is 145
        And the diastolic pressure is 95
        When I calculate the pulse pressure
        Then the value should be 50
