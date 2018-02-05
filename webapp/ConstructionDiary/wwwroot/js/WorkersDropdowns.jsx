class WorkerDropdown extends React.PureComponent {
    constructor(props) {
        super(props);
        this.mapValuesToOptions = this.mapValuesToOptions.bind(this);
    }
    mapValuesToOptions() {
        return this.props.options.map(o => {
            return (
                <option value={o.Value} key={o.Value}>{o.Text}</option> 
             );
        });
    }
    render() {
        return (
            <select id={`taskWorkerInput${this.props.num}`} className="task-worker-input" num={this.props.num}>
                <option value="0">{this.props.num === 1 ? "Odaberi radnika" : "Dodaj još jednog radnika na zadatak"}</option>
                {this.mapValuesToOptions()}
            </select>
        );
    }

}
class WorkersDropdowns extends React.PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            numDropdowns: 1,
            workers: [],
            values: {},
        }
        this.renderDropdowns = this.renderDropdowns.bind(this);
        this.generateOptions = this.generateOptions.bind(this);
        this.dropdownChange = this.dropdownChange.bind(this);
    }
    componentDidMount() {
        $('select').material_select();
        this.setState(() => ({ workers: window.workers }));
        $("#dropdowns-container").on('change', "select", this.dropdownChange);
    }
    componentDidUpdate() {
        $('select').material_select();
    }
    dropdownChange(e) {
        const $target = $(e.currentTarget);
        const dropdownNumber = $target.attr("num");value
        const value = $target.val();
        const dropdownAlreadyChanged = !!this.state.values[dropdownNumber];
        this.setState((prevState) => ({
            numDropdowns: dropdownAlreadyChanged ? prevState.numDropdowns : prevState.numDropdowns + 1,
            values: Object.assign(
                {},
                prevState.values,
                { [dropdownNumber]: e.currentTarget.value }
            )
        }));
    }
    renderDropdowns() {
        let dropdowns = [];
        for (let i = 0; i < this.state.numDropdowns; i++) {
            const dropdownNumber = i + 1;
            const selectedOptions = Object.keys(this.state.values).filter(k => parseInt(k, 10) !== dropdownNumber).map(k => this.state.values[k]);
            const currentDropdownOptions = this.generateOptions().filter(o => selectedOptions.indexOf(o.Value) === -1);
            dropdowns.push(
                <WorkerDropdown
                    key={i}
                    num={dropdownNumber}
                    options={currentDropdownOptions} />
            );
        }
        return dropdowns;
    }
    generateOptions() {
        return this.state.workers;
    }
    render() {
        return (
            <div id="dropdowns-container">
                <label htmlFor="taskWorkerInput" data-error="Obavezno je dodijeliti radnika zadatku" className="col-form-label">Odabir radnika</label>
                {this.renderDropdowns()}
            </div>
        );
    }
}

ReactDOM.render(
    <WorkersDropdowns />,
    document.getElementById("workers-dropdowns")
);