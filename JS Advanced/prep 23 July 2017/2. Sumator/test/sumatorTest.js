const Sumator = require('../sumator');
const expect = require('chai').expect;

describe("Test Sumator", function() {

    beforeEach(function () {
        sumator = new Sumator();
    })

    describe('Check if functions exist', function() {
        it('data is not undefined', function() {
            expect(sumator.data !== undefined).equal(true);
        })

        it('add num exists', function() {
            expect(Sumator.prototype.hasOwnProperty('add')).equal(true);
        })
        it('sum num exists', function() {
            expect(Sumator.prototype.hasOwnProperty('sumNums')).equal(true);
        })
        it('remove by filter exists', function() {
            expect(Sumator.prototype.hasOwnProperty('removeByFilter')).equal(true);
        })
        it('toString exists', function() {
            expect(Sumator.prototype.hasOwnProperty('toString')).equal(true);
        })
    })

    it("test if data length is empty ", function() {
        expect(sumator.data.length).equal(0);
    });

    describe("add func test", function() {
        it("add number", function() {
            sumator.add(5);
            sumator.add(4);
            sumator.add(3);
            expect(sumator.data.join(', ')).equal('5, 4, 3');
        });

        it("add text", function() {
            sumator.add('Kiril');
            sumator.add('Ivan');
            sumator.add('Gosho');
            expect(sumator.data.join(', ')).equal('Kiril, Ivan, Gosho');
        });

        it("add object", function() {
            sumator.add({name: 'Kiril'});
            sumator.add({});
            expect(sumator.data.join(', ')).equal('[object Object], [object Object]');
        });

        it("add mixed", function() {
            sumator.add({name: 'Kiril'});
            sumator.add(4);
            sumator.add('Gosho');
            expect(sumator.data.join(', ')).equal('[object Object], 4, Gosho');
        });
    });

    describe('Test sum nums', function() {
        it('sum only numbers', function(){
            sumator.add(5);
            sumator.add(4);
            sumator.add(3);
            expect(sumator.sumNums()).equal(12);
        })

        it('sum mixed no numbers', function(){
            sumator.add('Gosho');
            sumator.add({});
            sumator.add({name: 'Pesho'});
            expect(sumator.sumNums()).equal(0);
        })

        it('sum mixed with numbers', function(){
            sumator.add(4);
            sumator.add({});
            sumator.add(3);
            expect(sumator.sumNums()).equal(7);
        })
    })

    describe('Test remove by filter', function(){
        it('removes all odd numbers', function() {
            for (let i = 0; i <= 10; i++) {
                sumator.add(i);
            }

            sumator.removeByFilter((x) => x%2 !== 0);
            expect(sumator.data.join(', ')).equal('0, 2, 4, 6, 8, 10');
        })

        it('removes greater that 5 numbers', function() {
            for (let i = 0; i <= 5; i++) {
                sumator.add(i);
            }

            sumator.removeByFilter((x) => x > 5 );
            expect(sumator.data.join(', ')).equal('0, 1, 2, 3, 4, 5');
        })

        
        it('throws exceptoin', function() {
            for (let i = 0; i <= 5; i++) {
                sumator.add(i);
            }

            expect(() => sumator.removeByFilter(undefined)).to.throw();
        })
    })

    describe('Test toString func', function() {
        it('with items in array', function(){
            sumator.add(4);
            sumator.add('Gosho');
            expect(sumator.toString()).equal('4, Gosho');
        })

        it('without items in array', function(){
            expect(sumator.toString()).equal('(empty)');
        })
    })
});
