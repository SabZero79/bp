@BDD
Feature: Blood Pressure
Feature: Blood Pressure Category Calculation
    In order to categorize blood pressure correctly
    As a healthcare professional
    I want to see the blood pressure category based on systolic and diastolic values

    Scenario: Low Blood Pressure
        Given the systolic pressure is 85
        And the diastolic pressure is 55
        When I calculate the blood pressure category
        Then the category should be "Low"

    Scenario: Ideal Blood Pressure
        Given the systolic pressure is 115
        And the diastolic pressure is 75
        When I calculate the blood pressure category
        Then the category should be "Ideal"

    Scenario: Pre-High Blood Pressure
        Given the systolic pressure is 125
        And the diastolic pressure is 85
        When I calculate the blood pressure category
        Then the category should be "PreHigh"

    Scenario: High Blood Pressure
        Given the systolic pressure is 150
        And the diastolic pressure is 95
        When I calculate the blood pressure category
        Then the category should be "High"
