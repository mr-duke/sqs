import {describe, it, expect} from 'vitest'
import { mount } from '@vue/test-utils';
import App from './App.vue';

describe('Input check', () => {
    it('should return true for valid input within range', () => {
      const wrapper = mount(App, {
        data() {
          return {
            inputValue: '25',
          }
        }
      });
      const isValid = wrapper.vm.isValidInput();
      expect(isValid).toBe(true);
    });
    
    it('should return false for input smaller than minimum', () => {
      const wrapper = mount(App, {
        data() {
          return {
            inputValue: '-10',
          }
        }
      });
      const isValid = wrapper.vm.isValidInput();
      expect(isValid).toBe(false);
    });

    it('should return false for input greater than maximum', () => {
      const wrapper = mount(App, {
        data() {
          return {
            inputValue: '2000',
          }
        }
      });
      const isValid = wrapper.vm.isValidInput();
      expect(isValid).toBe(false);
    });

    it('should return false for invalid/nonsense input', () => {
      const wrapper = mount(App, {
        data() {
          return {
            inputValue: 'abc123def#!',
          }
        }
      });
      const isValid = wrapper.vm.isValidInput();
      expect(isValid).toBe(false);
    });

  });