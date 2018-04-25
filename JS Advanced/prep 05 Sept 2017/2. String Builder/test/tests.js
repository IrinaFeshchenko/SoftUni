const StringBuilder = require('../string-builder');
const expect = require('chai').expect;

describe("StringBuilder tests", function() {
    let builder;
    beforeEach(function() {
        builder = new StringBuilder('test');
    });

    it("test if append exist", function() {
        expect(Object.getPrototypeOf(builder).hasOwnProperty('append')).equal(true);
        expect(Object.getPrototypeOf(builder).hasOwnProperty('prepend')).equal(true);
        expect(Object.getPrototypeOf(builder).hasOwnProperty('insertAt')).equal(true);
        expect(Object.getPrototypeOf(builder).hasOwnProperty('remove')).equal(true);
        expect(Object.getPrototypeOf(builder).hasOwnProperty('toString')).equal(true);
    });

    it("it should return same string", function() {
        expect(builder.toString()).equal('test');
    });

    it("it should return empty string", function() {
        builder = new StringBuilder();
        expect(builder.toString()).equal('');
    });

    it("it should throw error", function() {
        expect(()=> builder = new StringBuilder(5)).to.throw(TypeError);
    });

    it("append", function() {
        builder.append(' function')
        expect(builder._stringArray.length).equal(13);
        expect(builder.toString()).equal('test function');
    });

    it("append error", function() {
        expect(()=> builder.append({})).to.throw(TypeError);
    });

    
    it("prepend", function() {
        builder.prepend('function ')
        expect(builder._stringArray.length).equal(13);
        expect(builder.toString()).equal('function test');
    });

    it("prepend error", function() {
        expect(()=> builder.prepend(10)).to.throw(TypeError);
    });

    it("insertAt", function() {
        builder.insertAt('ss', 2)
        expect(builder._stringArray.length).equal(6);
        expect(builder.toString()).equal('tessst');
    });

    it("insertAt error", function() {
        expect(()=> builder.insertAt([],2)).to.throw(TypeError);
    });

    it("remove", function() {
        builder.remove(1, 2)
        expect(builder._stringArray.length).equal(2);
        expect(builder.toString()).equal('tt');
    });
});
