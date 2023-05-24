import App from './App.vue'

describe('<App />', () => {
  beforeEach(() => {
    cy.mount(App)
  })

  it('Button text is correct', () => {
    cy.get('button').should('have.text', "Gotta catch 'em all!")
  })

  it('Enables submit button when input is within range', () => {
    const withinRangeValue = 50
    cy.get('input').clear().type(withinRangeValue)
    cy.get('button').should('be.enabled')
    cy.get('[data-cy=error-message]').should('not.exist')
  })

  it('Disables submit button and shows error message when input is outside of range', () => {  
    const outsideRangeValue = 2000
    cy.get('input').type(outsideRangeValue)
    cy.get('button').should('be.disabled')
    cy.get('[data-cy=error-message]').should('be.visible')
    cy.get('[data-cy=error-message]').should('have.text', "Input value must be between 1 and 1010")
  })

  it('Disables submit button and shows error message when input is invalid', () => {  
    cy.get('input').clear().type("abc")
    cy.get('button').should('be.disabled')
    cy.get('[data-cy=error-message]').should('be.visible')
    cy.get('[data-cy=error-message]').should('have.text', "Input value must be between 1 and 1010")
  })
  
})
