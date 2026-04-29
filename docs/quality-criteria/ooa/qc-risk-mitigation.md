
# Quality Criteria: Risk & Mitigation
Effective risk identification and mitigation are essential for ensuring project success and system robustness. This document provides a structured template and quality criteria for defining, evaluating, and maintaining risks and their mitigations, referencing best practices from "Applying UML and patterns by Craig Larman".

## Metadata
| Key               | Value                             |
|-------------------|-----------------------------------|
| Id                | QC-RISK                           |
| crossReference    | Applying UML and patterns by Craig Larman |

### Change Log
| Date       | Version | Description                     | Author        |
|------------|---------|---------------------------------|---------------|
| 2026-03-07 | 0001    | Initial creation of the document | Team 6       |

## Quality Criteria for Risk & Mitigation
When evaluating risks and their mitigations, consider the following quality criteria:
1. **Clarity and Specificity**: Risks and mitigations must be clearly described, with unambiguous language and context. Avoid vague or generic statements.
2. **Relevance**: Each risk should be directly related to project objectives, business requirements, or technical constraints.
3. **Traceability**: Every risk and mitigation must be traceable to a requirement, use case, or stakeholder concern.
4. **FURPS Coverage**: Quality criteria for each risk and mitigation must address Functionality, Usability, Reliability, Performance, and Supportability, as appropriate. See [docs/furps.md](../../furps.md).
5. **Measurability**: Define KPIs or metrics for each risk and mitigation to enable objective assessment. See [docs/kpi.md](../../kpi.md).
6. **Mitigation Effectiveness**: Mitigation actions must be actionable, realistic, and demonstrably reduce the likelihood or impact of the risk.
7. **Stakeholder Validation**: Risks and mitigations must be reviewed and validated by relevant stakeholders.
8. **Maintainability**: The risk register and mitigation actions should be easy to update as the project evolves.
9. **Documentation Quality**: All risks and mitigations must be documented with concise explanations and references to supporting material.
10. **Versioning and Change Log**: Every change to risks or mitigations must be logged with a version, date, and author.
11. **Language/Translation Compliance**: If the product owner’s language is not English, ensure translation and dual-file compliance.

## Authoring Patterns and Templates
For filename conventions, templates, and authoring examples, see `.github/instructions/risk-mitigation.instructions.md`.

### Example Risk & Mitigation Table

| Risk | Mitigation | Quality Criteria | Reference |
|------|------------|-----------------|-----------|
| High coupling between modules | Apply Facade or Mediator pattern | - Modules interact only via defined interfaces (Functionality, Supportability)<br>- Coupling metrics below threshold (Reliability, Performance)<br>- Encapsulation enforced (Usability) | Larman, Ch. 17, 18 |
| Low cohesion in classes | Refactor to increase cohesion | - Each class has a single, well-defined responsibility (Functionality)<br>- Cohesion metrics above threshold (Reliability)<br>- Fewer than 3 reasons to change per class (Supportability) | Larman, Ch. 17 |

## Validation
- Review risks and mitigations for clarity, traceability, and FURPS/KPI coverage.
- Verify that all placeholders are replaced with project-specific content.

## Maintenance
- Update the version and change log for major changes.
- Regularly review risks and mitigations for accuracy and relevance.

## Language
- Professional
- English
- If product owner domain language is different, use that language for the content while maintaining English for metadata and versioning. Save the file with a language code suffix (e.g., `qc-risk-mitigation.<language_code>.md`).
