let createList = require('../list-add-swap-shift-left-right');
const expect = require('chai').expect;

describe("createList", function() {

    let list;

    beforeEach(function() {
        list = createList();
    });

    describe("add", function() {
        it("multiple", function () {
            list.add('pesho');
            list.add('gosho');
            list.add(5)
            expect(list.toString()).equal('pesho, gosho, 5');
        });
    });

    describe("shiftLeft", function() {
        it("shifts correctly", function () {
            list.add('pesho');
            list.add('gosho');
            list.add(5)
            list.shiftLeft();
            expect(list.toString()).equal('gosho, 5, pesho');
        });
    });
    describe("shiftRight", function() {
        it("shifts correctly", function () {
            list.add('pesho');
            list.add('gosho');
            list.add(5)
            list.shiftRight();
            expect(list.toString()).equal('5, pesho, gosho');
        });
    });

    describe("swap", function() {
        it("first index negative", function () {
            list.add('pesho');
            list.add('gosho');
            list.add(5);
            list.add(6);

            expect(list.swap(2,3)).equal(true);
            expect(list.toString()).equal('pesho, gosho, 6, 5');

            expect(list.swap(-1,2)).equal(false);
            expect(list.swap(4,2)).equal(false);
            expect(list.swap({},2)).equal(false);
            expect(list.swap(0,2)).equal(true);
            expect(list.swap(2,2)).equal(false);
            expect(list.swap(2,-1)).equal(false);
            expect(list.swap(2,4)).equal(false);
            expect(list.swap(2,{})).equal(false);
            expect(list.swap(2,0)).equal(true);
            expect(list.swap(5,0)).equal(false);
            expect(list.swap(0,5)).equal(false);
            

        });
    });
});



