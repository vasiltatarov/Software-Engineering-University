class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        this.validate(username, salary, position, department);
        this.validateSalary(salary);

        let newEmployee = {
            username: username,
            salary: Number(salary),
            position: position
        }

        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        this.departments[department].push(newEmployee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let department = '';
        let maxSalary = 0;
        Object.entries(this.departments).forEach(([key, value]) => {
            let currSalary = 0;
            value.forEach(e => {
                currSalary += e.salary;
            });
            currSalary /= value.length;
            if (currSalary > maxSalary) {
                department = key;
                maxSalary = currSalary;
            }
        });

        if (department != '') {
            let result = `Best Department is: ${department}\nAverage salary: ${maxSalary.toFixed(2)}\n`;

            Object.values(this.departments[department])
                .sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))
                .forEach(e => {
                    result += `${e.username} ${e.salary} ${e.position}\n`;
                });

            return result.trim();
        }
    }

    //validate methods
    validate(...params) {
        if (params.some(p => p == undefined || p == null || p == '')) {
            throw new Error('Invalid input!');
        }
    }

    validateSalary(salary) {
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
    }
}

try {
    let c = new Company();
    c.addEmployee("Stanimir", 2000, "engineer", "Construction");
    c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
    c.addEmployee("Slavi", 500, "dyer", "Construction");
    c.addEmployee("Stan", 2000, "architect", "Construction");
    c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
    c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
    c.addEmployee("Gosho", 1350, "HR", "Human resources");
    console.log(c.bestDepartment());
} catch(er) {
    console.log(er);
}
